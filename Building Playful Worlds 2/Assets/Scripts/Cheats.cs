using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    public Transform parkourPos;
    public Transform templePos;
    public GameObject player;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) // teleports player to the end of the parkour section
        {
            player.transform.position = parkourPos.position;
        }

        if (Input.GetKeyDown(KeyCode.L)) // teleports player to the end of the temple parkour section
        {
            player.transform.position = templePos.position;
        }
    }
}
