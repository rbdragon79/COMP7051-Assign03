using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball")
        {
            string wallName = transform.name;
            PongGameManager.Score(wallName);
            other.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
