using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeMenuManager : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        if (!PlayerPrefs.HasKey("fromMazeSaved") || PlayerPrefs.GetInt("fromMazeSaved") == 0)
        {
            GameObject savedBtn = GameObject.FindWithTag("Save");
            savedBtn.SetActive(false);
        }
    }

    public void NewGame()
    {
        PlayerPrefs.GetInt("fromMazeSaved", 0);
        SceneManager.LoadScene("maze");
    }

    public void SavedGame()
    {
        PlayerPrefs.GetInt("fromMazeSaved", 1);
        SceneManager.LoadScene("maze");
    }
}
