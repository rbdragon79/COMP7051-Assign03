using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;

public class ConsoleView : MonoBehaviour
{
    ConsoleController console = new ConsoleController();

    public GameObject viewContainer; //Container for console view, should be a child of this GameObject
    public Text logTextArea;
    public InputField inputField;

    void Start()
    {
        if (console != null)
        {
            console.visibilityChanged += onVisibilityChanged;
            console.logChanged += onLogChanged;
        }
        updateLogStr(console.log);
    }

    ~ConsoleView()
    {
        console.visibilityChanged -= onVisibilityChanged;
        console.logChanged -= onLogChanged;
    }

    void Update()
    {
        //Toggle visibility when 'c' key pressed
        if (Input.GetKeyUp("c"))
        {
            toggleVisibility();
        }
    }

    void toggleVisibility()
    {
        setVisibility(!viewContainer.activeSelf);
    }

    void setVisibility(bool visible)
    {
        viewContainer.SetActive(visible);
    }

    void onVisibilityChanged(bool visible)
    {
        setVisibility(visible);
    }

    void onLogChanged(string[] newLog)
    {
        updateLogStr(newLog);
    }

    void updateLogStr(string[] newLog)
    {
        if (newLog == null)
        {
            logTextArea.text = "";
        }
        else
        {
            logTextArea.text = string.Join("\n", newLog);
        }
    }

    /// <summary>
    /// Event that should be called by anything wanting to submit the current input to the console.
    /// </summary>
    public void runCommand()
    {
        console.runCommandString(inputField.text);
        inputField.text = "";
    }
}