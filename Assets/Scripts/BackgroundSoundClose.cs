using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSoundClose : MonoBehaviour
{
    public GameObject backgroundsound;
    public GameObject backgroundsound2;
    public Toggle brightToggle;

    // Use this for initialization
    void Start()
    {
        backgroundsound2 = GameObject.Find("BackgroundSound2");
        backgroundsound = GameObject.Find("BackgroundSound");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 4") || Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (backgroundsound.GetComponent<AudioSource>().isPlaying || backgroundsound2.GetComponent<AudioSource>().isPlaying)
            {
                if (backgroundsound.GetComponent<AudioSource>().isPlaying)
                {
                    backgroundsound.GetComponent<AudioSource>().Pause();
                }
                else if (backgroundsound2.GetComponent<AudioSource>().isPlaying)
                {
                    backgroundsound2.GetComponent<AudioSource>().Pause();
                }

            }
            else
            {
                if (!backgroundsound.GetComponent<AudioSource>().isPlaying && brightToggle.isOn)
                {
                    backgroundsound.GetComponent<AudioSource>().Play();
                }
                else if (!backgroundsound2.GetComponent<AudioSource>().isPlaying && !brightToggle.isOn)
                {
                    backgroundsound2.GetComponent<AudioSource>().Play();
                }
            }
        }
    }
}
