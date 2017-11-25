using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {

    public float speed = 5f;
    private GameObject ball;
    private Vector3 ballPos;

	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        ball = GameObject.Find("Ball");
        ballPos = ball.transform.localPosition;

        if (transform.localPosition.y > ballPos.y)
        {
            transform.localPosition += new Vector3(0, -speed * Time.deltaTime, 0);
        }

        if (transform.localPosition.y < ballPos.y)
        {
            transform.localPosition += new Vector3(0, speed * Time.deltaTime, 0);
        }
    }
}
