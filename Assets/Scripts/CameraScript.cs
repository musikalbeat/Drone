using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
- Drone Camera
- Fixed Camera Positions Around Arena
- UI with buttons to control camera

- Reference 2 buttons: ArenaButton, DroneButton
- When DroneButton is pressed, opens up a panel with a selection of buttons of teams
*/
public class CameraScript : MonoBehaviour
{
    public GameObject arenaButton;
    public GameObject droneButton;
    public GameObject dronePanel;
    public GameObject cameraPositions;
    
    public GameObject blueDrones;
    public GameObject redDrones;

    private GameObject cam;

    private int arenaCounter = 0;
    private bool panelToggle = true;

    private bool droneMode = false;
    private string droneType;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (droneMode == true)
        {
            if (target != null)
            {
                cam.transform.position = target.transform.position + new Vector3(-5, 5, 0);
                cam.transform.LookAt(target.transform.position);
            }
            else
            {
                if (droneType == "blue")
                {
                    blueButtonPressed();
                }
                else
                {
                    redButtonPressed();
                }
            }
        }
    }

    public void arenaButtonPressed()
    {
        droneMode = false;
        arenaCounter += 1;
        
        if (arenaCounter >= cameraPositions.transform.childCount)
        {
            arenaCounter = 0;
        }

        cam.transform.position = cameraPositions.transform.GetChild(arenaCounter).position;
        cam.transform.rotation = cameraPositions.transform.GetChild(arenaCounter).rotation;
    }

    public void droneButtonPressed()
    {
        if (panelToggle == true)
        {
            dronePanel.SetActive(false);
            panelToggle = false;
        }
        else
        {
            dronePanel.SetActive(true);
            panelToggle = true;
        }
        
    }

    public void blueButtonPressed()
    {
        int randNum = Random.Range(0, blueDrones.transform.childCount);
        target = blueDrones.transform.GetChild(randNum).gameObject;
        droneMode = true;
        droneType = "blue";
    }

    public void redButtonPressed()
    {
        int randNum = Random.Range(0, redDrones.transform.childCount);
        target = redDrones.transform.GetChild(randNum).gameObject;
        droneMode = true;
        droneType = "red";
    }
}
