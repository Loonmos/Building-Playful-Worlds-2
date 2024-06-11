using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public UnityEvent PlatformMove;
    public UnityEvent PuzzleCompletion;

    public PlatformMovement platformMove;

    public List<GameObject> altarList = new List<GameObject>();
    public bool altarsActive;

    public GameObject starOn;
    public GameObject starOff;

    public bool levelPuzzle;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (levelPuzzle == true && Input.GetKeyDown(KeyCode.P)) // complete puzzle in level
        {
            PuzzleCompletion.Invoke();
        }

        if (levelPuzzle == false && Input.GetKeyDown(KeyCode.P)) // complete puzzle in temple
        {
            TurnStarOn();
            platformMove.canMove = true;
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player" && altarsActive == true)
    //    {
    //        PlatformMove.Invoke();
    //    }
    //}

    public void CheckAltars()
    {
        foreach (GameObject altar in altarList)
        
        if (altar.activeInHierarchy == false)
            {
                altarsActive = false;
                break;
            }
        else
            {
                altarsActive = true;
            }

        if (altarsActive == true)
        {
            if (levelPuzzle == true)
            {
                PuzzleCompletion.Invoke();
            }
            else // changed this recently, in case smt breaks
            {
                TurnStarOn();
                platformMove.canMove = true;
            }

        } 
        else
        {
            if (levelPuzzle == false) // changed this recently, in case smt breaks
            {
                TurnStarOff();
                platformMove.canMove = false;
            } 
        }
    }

    public void TurnStarOn()
    {
        starOn.SetActive(true);
        starOff.SetActive(false);
    }

    public void TurnStarOff()
    {
        starOn.SetActive(false);
        starOff.SetActive(true);
    }
}
