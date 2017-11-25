using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]

public class EndManager : MonoBehaviour {

    //public KeyCode key;
    public Button replayBtn;
    public Button mazeBtn;
    public Text message;

    void Start () {
        if(PlayerPrefs.GetString("winPong") == "yes")
        {
            message.text = "Congrats! You Won!";
        } else
        {
            message.text = "Sorry...you lose...";
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 7"))
        {
            replayBtn.onClick.Invoke();
            //SceneManager.LoadScene("playPong");
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 6"))
        {
            mazeBtn.onClick.Invoke();
            //SceneManager.LoadScene("maze");
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("playPong");
    }

    public void ReturnToMaze()
    {
        SceneManager.LoadScene("maze");
    }
}
