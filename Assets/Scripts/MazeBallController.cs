using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBallController : MonoBehaviour {

    public GameObject mazeBall;
    public float speed = 300f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown("joystick button 0"))
        {
            ThrowTheBall();
        }
	}

    void ThrowTheBall()
    {
        GameObject go = (GameObject)Instantiate(mazeBall, transform.position, Quaternion.identity);
        ThrowBall tb = go.GetComponent<ThrowBall>();
        tb.Throw(transform.forward * speed);
        Destroy(go, 2.5f);
    }
}
