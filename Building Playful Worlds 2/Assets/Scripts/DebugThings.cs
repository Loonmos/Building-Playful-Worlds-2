using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugThings : MonoBehaviour
{
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R");
            gameManager.SaveGameOutside();
        }
    }
}
