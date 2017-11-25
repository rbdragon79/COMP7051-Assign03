using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public float speed = 5f;
    private Rigidbody rb;
    private Vector3 vel;
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        Invoke("GoBall", 1);
    }

    void GoBall()
    {
        float startX = Random.Range(0, 2) == 0 ? -1 : 1;
        float startY = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector3(speed * startX, speed * startY, 0f);
    }

    void ResetBall()
    {
        vel = Vector3.zero;
        rb.velocity = vel;
        transform.position = Vector3.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }
}
