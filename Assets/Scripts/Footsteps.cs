using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    CharacterController CharacterController;
    public float walk_Speed = 1.0f;
    public GameObject footsteps;
    // Use this for initialization
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        footsteps = GameObject.Find("Footsteps");
    }

    // Update is called once per frame
    void Update()
    {
        if (!footsteps.GetComponent<AudioSource>().isPlaying)
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                if (walk_Speed >= 1.0f)
                {
                    //Debug.Log("walk");
                    footsteps.GetComponent<AudioSource>().Play();
                }
            }
        }
    }
}
