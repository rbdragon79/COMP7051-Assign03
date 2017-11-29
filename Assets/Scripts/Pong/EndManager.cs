using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour {

    public Text message;

    void Start () {
        if(PlayerPrefs.GetString("winPong") == "yes")
        {
            message.text = "Congrats! You Won!";
        } else
        {
            message.text = "Sorry...you lose...";
        }
    }
	
	public void Replay()
    {
        SceneManager.LoadScene("playPong");
    }

    public void ReturnToMaze()
    {
        PlayerPrefs.SetInt("fromPong", 1);
        SceneManager.LoadScene("maze");
    }
}
