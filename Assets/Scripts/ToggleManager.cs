using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour {

    NoiseFog noiseFog;
    Brightness brightness;
    public Light sun;
    public Light flashlight;
    public Material[] materials;

    public Toggle nightToggle;
    public Toggle fogToggle;
    public Toggle ghostToggle;
    public Toggle flashlightToggle;
    public Toggle musicToggle;

    // Use this for initialization
    void Start () {
        noiseFog = GetComponent<NoiseFog>();
        brightness = GetComponent<Brightness>();
    }
	
	// Update is called once per frame
	void Update () {

        // Night Mode
        if (Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown("joystick button 1"))
        {
            nightToggle.isOn = !nightToggle.isOn;
            brightness.enabled = !brightness.enabled;
            sun.enabled = !sun.enabled;
        }

        // Fog Mode
        if (Input.GetKeyDown(KeyCode.F) ||  Input.GetKeyDown("joystick button 2"))
        {
            fogToggle.isOn = !fogToggle.isOn;
            noiseFog.enabled = !noiseFog.enabled;

        }

        // Ghost Mode
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown("joystick button 3"))
        {
            ghostToggle.isOn = !ghostToggle.isOn;

            foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
            {
                if (gameObj.name == "Wall")
                {
                    Color color = gameObj.GetComponent<Renderer>().material.color;
                    BoxCollider collider = gameObj.GetComponent<BoxCollider>();
                    collider.enabled = !collider.enabled;
                    if (!collider.enabled)
                    {
                        switch (gameObj.tag)
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
                    }
                    else
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

        // Flashlight
        if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown("joystick button 5"))
        {
            flashlightToggle.isOn = !flashlightToggle.isOn;
            flashlight.enabled = !flashlight.enabled;
        }

        // Background Music
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown("joystick button 4"))
        {
            musicToggle.isOn = !musicToggle.isOn;
            //music.enabled = !music.enabled;
        }

    }
}
