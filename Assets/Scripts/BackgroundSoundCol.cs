using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundSoundCol : MonoBehaviour
{

    public GameObject other;
    //AudioSource audioSource;
    public GameObject other2;
    // Use this for initialization
    void Start()
    {
        // audioSource = GetComponent<AudioSource>();
        other = GameObject.Find("BackgroundSound");
        other2 = GameObject.Find("BackgroundSound2");
    }

    // Update is called once per frame
    void Update()
    {
        if (other.GetComponent<AudioSource>().isPlaying)
        {
            if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.N))
            {
                other.GetComponent<AudioSource>().Stop();
                other2.GetComponent<AudioSource>().Play();
                //this.audioSource.Play();

            }

        }
        else if (other2.GetComponent<AudioSource>().isPlaying)
        {
            if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.N))
            {

                //this.audioSource.Stop();

                other.GetComponent<AudioSource>().Play();
                other2.GetComponent<AudioSource>().Stop();
            }

        }
    }
}
