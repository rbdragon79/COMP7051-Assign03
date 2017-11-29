using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMazeManager : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        int score = (PlayerPrefs.GetInt("mazeTimer") * 100) + PlayerPrefs.GetInt("mazeScore");
        scoreText.text = score.ToString("D5");
    }

    public void ReturnToMaze()
    {
        Debug.Log("Return to Maze");
        SceneManager.LoadScene("maze");
    }

    public void QuitGame()
    {
        PlayerPrefs.GetInt("fromMazeSaved", 0);
        Application.Quit();
    }
}