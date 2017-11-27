using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int timer;
    public Text timerText;
    public Text survivalTimeText;
    public GameObject player;
    public GameObject enemy;
    public GameObject endPanel;
    public Toggle ghostToggle;
    private static bool gameEnd = false;
    public Light sun;

    // Use this for initialization
    private void Awake()
    {
        BeginGame();
    }

    // Update is called once per frame
    private void Update()
    {
        timerText.text = timer.ToString();
        if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown("joystick button 7"))
        {
            RestartGame();
        }
    }

    private void BeginGame()
    {
        gameEnd = false;
        endPanel.SetActive(false);
        ghostToggle.isOn = false;
        sun.enabled = !sun.enabled;
        GameObject maze = (GameObject)Instantiate(Resources.Load("Maze"));
        GameObject enemyGO = (GameObject)Instantiate(enemy, new Vector3(-7.5f, 0, 7.5f), Quaternion.identity);
        player.transform.position = new Vector3(9.5f, 0, -9.5f);
        timer = 0;
        StartCoroutine("SurvivalTime");
    }

    private void RestartGame()
    {        
        if(gameEnd)
        {
            endPanel.SetActive(false);
        } else
        {
            StopCoroutine("SurvivalTime");
        }        
        BeginGame();
    }

    public void EndGame()
    {
        StopCoroutine("SurvivalTime");
        endPanel.SetActive(true);
        survivalTimeText.text = "You were caught\n"
            + "You survived " + timer + " seconds\n"
            + "Try Again";
        gameEnd = true;
    }

    // Increase the timer by 1 each second passed
    IEnumerator SurvivalTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timer++;
        }
    }
}
