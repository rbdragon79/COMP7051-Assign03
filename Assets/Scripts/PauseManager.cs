using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

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
