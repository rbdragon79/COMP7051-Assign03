using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    public void ReturnToMaze()
    {
        Debug.Log("Return to Maze");
        Debug.Log("playerX: " + PlayerPrefs.GetFloat("playerX").ToString());
        Debug.Log("playerZ: " + PlayerPrefs.GetFloat("playerZ").ToString());
        Debug.Log("enemyX: " + PlayerPrefs.GetFloat("enemyX").ToString());
        Debug.Log("enemyZ: " + PlayerPrefs.GetFloat("enemyZ").ToString());
        Debug.Log("fromMazeSaved: " + PlayerPrefs.GetInt("fromMazeSaved").ToString());
        Debug.Log("mazeTimer: " + PlayerPrefs.GetInt("mazeTimer").ToString());
        SceneManager.LoadScene("maze");
    }

    public void QuitGame()
    {
        PlayerPrefs.GetInt("fromMazeSaved", 0);
        Application.Quit();
    }
}
