using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PongGameManager : MonoBehaviour
{

    public static int p1Score;
    public static int p2Score;
    public Text p1;
    public Text p2;
    public GameObject theBall;

    private void Awake()
    {
        p1Score = 0;
        p2Score = 0;
    }

    void Update()
    {
        p1.text = p1Score.ToString();
        p2.text = p2Score.ToString();

        if(p1Score == 5 || p2Score == 5)
        {
            if(p1Score == 5)
            {
                PlayerPrefs.SetString("winPong", "yes");
            } else
            {
                PlayerPrefs.SetString("winPong", "no");
            }
            SceneManager.LoadScene("endPong");
        }
    }

    public static void Score(string wallID)
    {
        if (wallID == "Right")
        {
            p1Score++;
        }
        else
        {
            p2Score++;
        }
    }
}
