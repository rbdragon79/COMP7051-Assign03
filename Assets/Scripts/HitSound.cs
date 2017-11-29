using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    AudioSource audioSource;
    public PlayerMove pm;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pm.GoHitWall += Pm_GoHitWall;
    }

    private void Pm_GoHitWall()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
