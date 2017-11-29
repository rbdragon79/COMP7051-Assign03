using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeMenuManager : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Debug.Log("playerX: " + PlayerPrefs.GetFloat("playerX").ToString());
        Debug.Log("playerZ: " + PlayerPrefs.GetFloat("playerZ").ToString());
        Debug.Log("enemyX: " + PlayerPrefs.GetFloat("enemyX").ToString());
        Debug.Log("enemyZ: " + PlayerPrefs.GetFloat("enemyZ").ToString());
        Debug.Log("fromMazeSaved: " + PlayerPrefs.GetInt("fromMazeSaved").ToString());
        if (!PlayerPrefs.HasKey("fromMazeSaved") || PlayerPrefs.GetInt("fromMazeSaved") == 0)
        {
            Debug.Log("No Save Found");
            GameObject savedBtn = GameObject.FindWithTag("Save");
            savedBtn.SetActive(false);
        }
    }

    public void NewGame()
    {
        Debug.Log("New Game Started");
        PlayerPrefs.GetInt("fromMazeSaved", 0);
        SceneManager.LoadScene("maze");
    }

    public void SavedGame()
    {
        Debug.Log("Saved Game Started");
        PlayerPrefs.GetInt("fromMazeSaved", 1);
        SceneManager.LoadScene("maze");
    }
}
