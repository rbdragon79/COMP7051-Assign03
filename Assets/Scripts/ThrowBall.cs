using UnityEngine;
using UnityEngine.UI;

public class ThrowBall : MonoBehaviour {

    GameObject enemy;
    GameObject player;
    public GameObject enemyPrefab;
    public Text scoreText;
    public int score;

    private void Awake()
    {
        enemy = GameObject.FindWithTag("Enemy");
        player = GameObject.Find("PlayerBady");
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        score = PlayerPrefs.GetInt("mazeScore");
    }

    public void Throw(Vector3 force)
    {
        GetComponent<Rigidbody>().AddForce(force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == enemy)
        {
            Destroy(gameObject);
            Destroy(enemy, .025f);
            score += 100;
            PlayerPrefs.SetInt("mazeScore", score);
            scoreText.text = "SCORE: " + score.ToString("D5");

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