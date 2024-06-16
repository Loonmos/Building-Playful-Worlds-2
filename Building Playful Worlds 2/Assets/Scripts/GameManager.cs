using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Checks")]
    public bool levelCompleted;
    public bool templeCompleted;
    public bool abilityGot;

    [Header("Outside World")]
    public Transform playerPosOut;
    public Transform vase1PosOut;
    public Transform vase2PosOut;
    public Transform vase3PosOut;
    public Transform vase4PosOut;

    public GameObject playerOut;
    public GameObject vase1Out;
    public GameObject vase2Out;
    public GameObject vase3Out;
    public GameObject vase4Out;

    [Header("Temple")]
    public Transform playerPosTemple;
    public Transform vase1PosTemple;
    public Transform vase2PosTemple;
    public Transform vase3PosTemple;
    public Transform vase4PosTemple;

    public GameObject playerTemple;
    public GameObject vase1Temple;
    public GameObject vase2Temple;
    public GameObject vase3Temple;
    public GameObject vase4Temple;

    public void SaveGameOutside()
    {
        // save player pos
        playerOut = GameObject.FindGameObjectWithTag("Player");
        playerPosOut.position = playerOut.transform.position;

        // save vase positions
        vase1Out = GameObject.Find("BigVase 1");
        vase1PosOut.position = vase1Out.transform.position;

        vase2Out = GameObject.Find("BigVase 2");
        vase2PosOut.position = vase2Out.transform.position;

        vase3Out = GameObject.Find("SmallVase 1");
        vase3PosOut.position = vase3Out.transform.position;
    }

    public void LoadGameOutside()
    {
        // load player pos
        playerOut = GameObject.FindGameObjectWithTag("Player");
        playerOut.transform.position = playerPosOut.position;

        // load vase positions
        vase1Out = GameObject.Find("BigVase 1");
        vase1Out.transform.position = vase1PosOut.position;

        vase2Out = GameObject.Find("BigVase 2");
        vase2Out.transform.position = vase2PosOut.position;

        vase3Out = GameObject.Find("SmallVase 1");
        vase3Out.transform.position = vase3PosOut.position;
    }

    public void SaveGameTemple()
    {
        // save player pos
        playerTemple = GameObject.FindGameObjectWithTag("Player");
        playerPosTemple.position = playerTemple.transform.position;

        // save vase positions
        vase1Temple = GameObject.Find("BigVase 1");
        vase1PosTemple.position = vase1Temple.transform.position;

        vase2Temple = GameObject.Find("BigVase 2");
        vase2PosTemple.position = vase2Temple.transform.position;

        vase3Temple = GameObject.Find("SmallVase 1");
        vase3PosTemple.position = vase3Temple.transform.position;

        vase4Temple = GameObject.Find("SmallVase 2");
        vase4PosTemple.position = vase4Temple.transform.position;
    }

    public void LoadGameTemple()
    {
        // load player pos
        playerTemple = GameObject.FindGameObjectWithTag("Player");
        playerTemple.transform.position = playerPosTemple.position;

        // load vase positions
        vase1Temple = GameObject.Find("BigVase 1");
        vase1Temple.transform.position = vase1PosTemple.position;

        vase2Temple = GameObject.Find("BigVase 2");
        vase2Temple.transform.position = vase2PosTemple.position;

        vase3Temple = GameObject.Find("SmallVase 1");
        vase3Temple.transform.position = vase3PosTemple.position;

        vase4Temple = GameObject.Find("SmallVase 2");
        vase4Temple.transform.position = vase4PosTemple.position;
    }
}
