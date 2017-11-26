using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour {

    NoiseFog noiseFog;
    public Toggle fogToggle;
    Brightness brightness;
    public Toggle brightToggle;
    public Toggle ghostToggle;
    public Light sun;
    public Material[] materials;

    // Use this for initialization
    void Start () {
        noiseFog = GetComponent<NoiseFog>();
        brightness = GetComponent<Brightness>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F) ||  Input.GetKeyDown("joystick button 2"))
        {
            fogToggle.isOn = !fogToggle.isOn;
            noiseFog.enabled = !noiseFog.enabled;

        }

        if(Input.GetKeyDown(KeyCode.N) ||  Input.GetKeyDown("joystick button 1"))
        {
            brightToggle.isOn = !brightToggle.isOn;
            brightness.enabled = !brightness.enabled;
            sun.enabled = !sun.enabled;
        }

        if (Input.GetKeyDown(KeyCode.W) ||  Input.GetKeyDown("joystick button 3"))
        {
            ghostToggle.isOn = !ghostToggle.isOn;

            foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
            {
                if(gameObj.name == "Wall")
                {
                    Color color = gameObj.GetComponent<Renderer>().material.color;
                    BoxCollider collider = gameObj.GetComponent<BoxCollider>();
                    collider.enabled = !collider.enabled;
                    if(!collider.enabled)
                    {
                        switch(gameObj.tag)
                        {
                            case "WallNorth":
                                gameObj.GetComponent<Renderer>().material = materials[1];
                                break;
                            case "WallEast":
                                gameObj.GetComponent<Renderer>().material = materials[3];
                                break;
                            case "WallSouth":
                                gameObj.GetComponent<Renderer>().material = materials[5];
                                break;
                            case "WallWest":
                                gameObj.GetComponent<Renderer>().material = materials[7];
                                break;
                            case "PongRoomWall":
                                collider.enabled = !collider.enabled;
                                break;
                        }
                    } else
                    {
                        switch (gameObj.tag)
                        {
                            case "WallNorth":
                                gameObj.GetComponent<Renderer>().material = materials[0];
                                break;
                            case "WallEast":
                                gameObj.GetComponent<Renderer>().material = materials[2];
                                break;
                            case "WallSouth":
                                gameObj.GetComponent<Renderer>().material = materials[4];
                                break;
                            case "WallWest":
                                gameObj.GetComponent<Renderer>().material = materials[6];
                                break;
                        }
                    }                   
                }
            }
        }
    }
}
