using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    private GameManager gameManager;

    public bool outside;
    public bool temple;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (outside == true)
        {
            SaveGameOutside();
        }
        
        if (temple == true)
        {
            SaveGameTemple();
        }
    }

    public void SaveGameOutside()
    {
        // save player pos
        gameManager.playerOut = GameObject.FindGameObjectWithTag("Player");
        gameManager.playerPosOut.position = gameManager.playerOut.transform.position;

        // save vase positions
        gameManager.vase1Out = GameObject.Find("BigVase 1");
        gameManager.vase1PosOut.position = gameManager.vase1Out.transform.position;

        gameManager.vase2Out = GameObject.Find("BigVase 2");
        gameManager.vase2PosOut.position = gameManager.vase2Out.transform.position;

        gameManager.vase3Out = GameObject.Find("SmallVase 1");
        gameManager.vase3PosOut.position = gameManager.vase3Out.transform.position;
    }

    public void SaveGameTemple()
    {
        // save player pos
        gameManager.playerTemple = GameObject.FindGameObjectWithTag("Player");
        gameManager.playerPosTemple.position = gameManager.playerTemple.transform.position;

        // save vase positions
        gameManager.vase1Temple = GameObject.Find("BigVase 1");
        gameManager.vase1PosTemple.position = gameManager.vase1Temple.transform.position;

        gameManager.vase2Temple = GameObject.Find("BigVase 2");
        gameManager.vase2PosTemple.position = gameManager.vase2Temple.transform.position;

        gameManager.vase3Temple = GameObject.Find("SmallVase 1");
        gameManager.vase3PosTemple.position = gameManager.vase3Temple.transform.position;

        gameManager.vase4Temple = GameObject.Find("SmallVase 2");
        gameManager.vase4PosTemple.position = gameManager.vase4Temple.transform.position;
    }
}
