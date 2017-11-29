using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public void Play () {
        SceneManager.LoadScene("playPong");
	}

    public void ReturnToMaze()
    {
        PlayerPrefs.SetInt("fromPong", 1);
        SceneManager.LoadScene("maze");
    }
}
