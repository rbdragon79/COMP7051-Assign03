using UnityEngine;

public class ThrowBall : MonoBehaviour {

    GameObject enemy;
    GameObject player;
    public GameObject enemyPrefab;

    private void Awake()
    {
        enemy = GameObject.FindWithTag("Enemy");
        player = GameObject.Find("PlayerBady");
    }

    public void Throw(Vector3 force)
    {
        GetComponent<Rigidbody>().AddForce(force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == enemy)
        {
            //Debug.Log("Enemy Hit!");
            Destroy(gameObject);
            Destroy(enemy);
            // Respawn Enemy In NorthWest Quadrant
            if (player.transform.position.x > 0 && player.transform.position.z < 0)
            {
                //Debug.Log("Respawn Enemy In NorthWest Quadrant");
                GameObject enemyGO = (GameObject)Instantiate(enemyPrefab, new Vector3(-5.5f, 0, 5.5f), Quaternion.identity);
            }

            // Respawn Enemy in SouthWest Quadrant
            if (player.transform.position.x > 0 && player.transform.position.z > 0)
            {
                //Debug.Log("Respawn Enemy In SouthWest Quadrant");
                GameObject enemyGO = (GameObject)Instantiate(enemyPrefab, new Vector3(-5.5f, 0, -5.5f), Quaternion.identity);
            }

            // Respawn Enemy in SouthEast Quadrant
            if (player.transform.position.x < 0 && player.transform.position.z > 0)
            {
                //Debug.Log("Respawn Enemy In SouthEast Quadrant");
                GameObject enemyGO = (GameObject)Instantiate(enemyPrefab, new Vector3(5.5f, 0, -5.5f), Quaternion.identity);
            }

            // Respawn Enemy in NorthEast Quadrant
            if (player.transform.position.x < 0 && player.transform.position.z < 0)
            {
                //Debug.Log("Respawn Enemy In NorthEast Quadrant");
                GameObject enemyGO = (GameObject)Instantiate(enemyPrefab, new Vector3(5.5f, 0, 5.5f), Quaternion.identity);
            }
        } else
        {
            //Debug.Log("Other Things Hit!");
            Destroy(gameObject, 2.5f);
        }
    }
}