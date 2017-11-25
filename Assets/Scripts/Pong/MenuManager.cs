using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]

public class MenuManager : MonoBehaviour {

    //public KeyCode key;
    public Button button;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 7"))
        {
            button.onClick.Invoke();
            //Play();
        }
    }

    public void Play () {
        SceneManager.LoadScene("playPong");
	}
}
