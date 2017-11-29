using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

    Transform player;
    NavMeshAgent nav;
    GameObject gameManager;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        gameManager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
        nav.SetDestination(player.position);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "PlayerBady")
        {
            nav.isStopped = true;
            gameManager.GetComponent<GameManager>().EndGame();
        }
    }
}
