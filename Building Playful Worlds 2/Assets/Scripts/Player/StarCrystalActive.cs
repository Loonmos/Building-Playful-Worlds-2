using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCrystalActive : MonoBehaviour
{
    private GameManager gameManager;
    public bool starActive;
    
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        if (gameManager.levelCompleted == true)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void TurnOn()
    {
        this.gameObject.SetActive(true);
    }

    public void TurnOff()
    {
        this.gameObject.SetActive(false);
    }
}
