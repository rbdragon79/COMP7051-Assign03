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
            score += 500;
            PlayerPrefs.SetInt("mazeScore", score);
            scoreText.text = "SCORE: " + score.ToString("D5");
            GameObject enemyGO = (GameObject)Instantiate(enemyPrefab, new Vector3(-7.5f, 0, 7.5f), Quaternion.identity);
        }
        else
        {
            Destroy(gameObject, 2.5f);
        }
    }
}