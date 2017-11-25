using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;

public delegate void CommandHandler(string[] args);

public class ConsoleController
{
    public delegate void LogChangedHandler(string[] log);
    public event LogChangedHandler logChanged;

    public delegate void VisibilityChangedHandler(bool visible);
    public event VisibilityChangedHandler visibilityChanged;

    Camera cam;
    GameObject p1;
    GameObject p2;
    GameObject ball;

    class CommandRegistration
    {
        public string command { get; private set; }
        public CommandHandler handler { get; private set; }
        public string help { get; private set; }

        public CommandRegistration(string command, CommandHandler handler, string help)
        {
            this.command = command;
            this.handler = handler;
            this.help = help;
        }
    }

    const int scrollbackSize = 20;

    Queue<string> scrollback = new Queue<string>(scrollbackSize);
    List<string> commandHistory = new List<string>();
    Dictionary<string, CommandRegistration> commands = new Dictionary<string, CommandRegistration>();

    public string[] log { get; private set; }

    public ConsoleController()
    {
        registerCommand("blue", blueBack, "Changes the background to blue.");
        registerCommand("blk", blackBack, "Changes the background to black.");
        registerCommand("neg", negative, "Reverses the original color scheme.");
        registerCommand("reset", resetColors, "Changes to the original color scheme.");
        registerCommand("help", help, "Print this help.");
    }

    void registerCommand(string command, CommandHandler handler, string help)
    {
        commands.Add(command, new CommandRegistration(command, handler, help));
    }

    public void appendLogLine(string line)
    {
        Debug.Log(line);

        if (scrollback.Count >= ConsoleController.scrollbackSize)
        {
            scrollback.Dequeue();
        }
        scrollback.Enqueue(line);

        log = scrollback.ToArray();
        if (logChanged != null)
        {
            logChanged(log);
        }
    }

    public void runCommandString(string commandString)
    {
        appendLogLine("> " + commandString);

        string[] commandSplit = parseArguments(commandString);
        string[] args = new string[0];
        if (commandSplit.Length < 1)
        {
            appendLogLine(string.Format("Unable to process command '{0}'", commandString));
            return;

        }
        else if (commandSplit.Length >= 2)
        {
            int numArgs = commandSplit.Length - 1;
            args = new string[numArgs];
            Array.Copy(commandSplit, 1, args, 0, numArgs);
        }
        runCommand(commandSplit[0].ToLower(), args);
        commandHistory.Add(commandString);
    }

    public void runCommand(string command, string[] args)
    {
        CommandRegistration reg = null;
        if (!commands.TryGetValue(command, out reg))
        {
            appendLogLine(string.Format("Unknown command '{0}', type 'help' for list.", command));
        }
        else
        {
            if (reg.handler == null)
            {
                appendLogLine(string.Format("Unable to process command '{0}', handler was null.", command));
            }
            else
            {
                reg.handler(args);
            }
        }
    }

    static string[] parseArguments(string commandString)
    {
        LinkedList<char> parmChars = new LinkedList<char>(commandString.ToCharArray());
        bool inQuote = false;
        var node = parmChars.First;
        while (node != null)
        {
            var next = node.Next;
            if (node.Value == '"')
            {
                inQuote = !inQuote;
                parmChars.Remove(node);
            }
            if (!inQuote && node.Value == ' ')
            {
                node.Value = '\n';
            }
            node = next;
        }
        char[] parmCharsArr = new char[parmChars.Count];
        parmChars.CopyTo(parmCharsArr, 0);
        return (new string(parmCharsArr)).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
    }

    void blueBack(string[] args)
    {
        colorChangeCam();
        cam.backgroundColor = Color.blue;
    }

    void blackBack(string[] args)
    {
        colorChangeCam();
        cam.backgroundColor = Color.black;
    }

    void negative(string[] args)
    {
        colorChangeCam();
        cam.backgroundColor = Color.white;

        findObjects();

        p1.GetComponent<Renderer>().material.color = Color.black;
        p2.GetComponent<Renderer>().material.color = Color.black;
        ball.GetComponent<Renderer>().material.color = Color.black;
    }

    void resetColors(string[] args)
    {
        colorChangeCam();
        cam.backgroundColor = Color.black;

        findObjects();

        p1.GetComponent<Renderer>().material.color = Color.white;
        p2.GetComponent<Renderer>().material.color = Color.white;
        ball.GetComponent<Renderer>().material.color = Color.white;
    }

    void help(string[] args)
    {
        foreach (CommandRegistration reg in commands.Values)
        {
            appendLogLine(string.Format("{0}: {1}", reg.command, reg.help));
        }
    }

    void findObjects()
    {
        p1 = GameObject.Find("Paddle1");
        p2 = GameObject.Find("Paddle2");
        ball = GameObject.Find("Ball");
    }

    void colorChangeCam()
    {
        cam = Camera.main;
        cam.clearFlags = CameraClearFlags.Color;
    }
}