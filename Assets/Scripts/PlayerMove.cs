using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController CharacterController;
    //Rigidbody rigidBody;
    public float walk_Speed = 1.0f;
    public float turn_Speed = 100.0f;

    void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        //rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Changed the Horizontal Axis to turn left and right
        transform.Rotate(0, Input.GetAxis("Horizontal") * turn_Speed * Time.deltaTime, 0);

        float vertical = Input.GetAxis("Vertical");
        Vector3 moveForward = transform.forward * vertical * walk_Speed;
        CharacterController.SimpleMove(moveForward);
    }

    public delegate void PlayCollisionDelegate();
    public event PlayCollisionDelegate GoHitWall;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Rigidbody body = hit.collider.attachedRigidbody;
        if (hit.gameObject.name == "Wall")
        {
            GoHitWall.Invoke();
        }
    }
}
