using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    public void ReturnToMaze()
    {
        SceneManager.LoadScene("maze");
    }

    public void QuitGame()
    {
        PlayerPrefs.GetInt("fromMazeSaved", 0);
        Application.Quit();
    }
}
