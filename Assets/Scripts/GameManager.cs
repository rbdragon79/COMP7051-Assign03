﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int timer;
    public Text timerText;
    public Text scoreText;
    public GameObject player;
    public GameObject enemy;
    public Toggle ghostToggle;
    public Light sun;

    GameObject maze;
    GameObject enemyGO;
    float playerX, playerZ, enemyX, enemyZ;

    // Use this for initialization
    private void Awake()
    {
        playerX = 9.5f;  // PlayerPrefs.GetFloat("playerX", 9.5f);
        playerZ = -9.5f; // PlayerPrefs.GetFloat("playerZ", -9.5f);
        enemyX = -7.5f;  // PlayerPrefs.GetFloat("enemyX", -7.5f);
        enemyZ = 7.5f;   // PlayerPrefs.GetFloat("enemyZ", 7.5f);
        BeginGame();
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log("PlayerPrefs: " + PlayerPrefs.GetFloat("enemyX") + ", " + PlayerPrefs.GetFloat("enemyZ"));
        Debug.Log("Enemy Location: " + GameObject.FindGameObjectWithTag("Enemy").transform.position);

        timerText.text = "TIME: " + timer.ToString();
        PlayerPrefs.SetInt("mazeTimer", timer);

        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown("joystick button 6"))
        {
            GameObject enemyClone = GameObject.FindGameObjectWithTag("Enemy");
            PlayerPrefs.SetFloat("playerX", player.transform.position.x);
            PlayerPrefs.SetFloat("playerZ", player.transform.position.z);
            PlayerPrefs.SetFloat("enemyX", enemyClone.transform.position.x);
            PlayerPrefs.SetFloat("enemyZ", enemyClone.transform.position.z);
            PlayerPrefs.SetInt("fromMazeSaved", 1);
            SceneManager.LoadScene("pauseMaze");
        }

        if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown("joystick button 7"))
        {
            RestartGame();
        }
    }

    private void BeginGame()
    {
        if (!PlayerPrefs.HasKey("fromPong"))
        {
            PlayerPrefs.SetInt("fromPong", 0);
        }

        if (!PlayerPrefs.HasKey("fromMazeSaved"))
        {
            PlayerPrefs.SetInt("fromMazeSaved", 0);
        }

        if (PlayerPrefs.GetInt("fromMazeSaved") == 1)
        {
            Debug.Log("fromMazeSaved: 1");
            playerX = PlayerPrefs.GetFloat("playerX");
            playerZ = PlayerPrefs.GetFloat("playerZ");
            enemyX = PlayerPrefs.GetFloat("enemyX");
            enemyZ = PlayerPrefs.GetFloat("enemyZ");
        }

        if (PlayerPrefs.GetInt("fromPong") == 0 && PlayerPrefs.GetInt("fromMazeSaved") == 0)
        {
            PlayerPrefs.SetInt("mazeScore", 0);
            PlayerPrefs.SetInt("mazeTimer", 0);
        }

        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            Debug.Log("Enemy Destroyed");
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }

        //Debug.Log(playerX.ToString() + ", " + playerZ.ToString() + ", " + enemyX.ToString() + ", " + enemyZ.ToString());
        timer = PlayerPrefs.GetInt("mazeTimer");
        scoreText.text = "SCORE: " + PlayerPrefs.GetInt("mazeScore").ToString("D5");
        timerText.text = "TIME: " + PlayerPrefs.GetInt("mazeTimer").ToString();
        PlayerPrefs.SetInt("fromPong", 0);
        ghostToggle.isOn = false;
        sun.enabled = !sun.enabled;
        maze = (GameObject)Instantiate(Resources.Load("Maze"));
        enemyGO = Instantiate(enemy, new Vector3(enemyX, 0, enemyZ), Quaternion.identity);
        player.transform.position = new Vector3(playerX, 0, playerZ);
        
        StartCoroutine("SurvivalTime");
    }

    private void RestartGame()
    {        
        Destroy(maze);
        BeginGame();
    }

    public void EndGame()
    {
        StopCoroutine("SurvivalTime");
        PlayerPrefs.SetInt("fromMazeSaved", 0);
        SceneManager.LoadScene("endMaze");
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
