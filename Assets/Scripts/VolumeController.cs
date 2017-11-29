using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{

    public GameObject other;
    public GameObject other2;
    float mySliderValue;
    float originalValue;
    // Use this for initialization
    void Start()
    {
        other2 = GameObject.Find("BackgroundSound2");
        other = GameObject.Find("BackgroundSound");
        mySliderValue = 0.5f;
        originalValue = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (other.GetComponent<AudioSource>().isPlaying)
        {
            if (Input.GetKeyDown("joystick button 2") || Input.GetKeyDown(KeyCode.F))
            {
                if (other.GetComponent<AudioSource>().volume == originalValue)
                {
                    // mySliderValue = GUI.HorizontalSlider(new Rect(25, 25, 200, 60), mySliderValue, 0.0F, 1.0F);
                    other.GetComponent<AudioSource>().volume = mySliderValue;


                }
                else
                {
                    other.GetComponent<AudioSource>().volume = originalValue;
                }

            }
        }
        else if (other2.GetComponent<AudioSource>().isPlaying)
        {
            if (Input.GetKeyDown("joystick button 2") || Input.GetKeyDown(KeyCode.F))
            {
                if (other2.GetComponent<AudioSource>().volume == originalValue)
                {
                    // mySliderValue = GUI.HorizontalSlider(new Rect(25, 25, 200, 60), mySliderValue, 0.0F, 1.0F);
                    other2.GetComponent<AudioSource>().volume = mySliderValue;


                }
                else
                {
                    other2.GetComponent<AudioSource>().volume = originalValue;
                }
            }
        }
    }
}
