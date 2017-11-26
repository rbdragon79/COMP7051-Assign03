using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnBounce : MonoBehaviour {

    public AudioClip ballBounce;

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = ballBounce;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            GetComponent<AudioSource>().Play();
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            GetComponent<AudioSource>().Play();
        }
    }*/
}
