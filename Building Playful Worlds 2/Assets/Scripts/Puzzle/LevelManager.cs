using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public UnityEvent PlatformMove;
    public UnityEvent PuzzleCompletion;

    public List<GameObject> altarList = new List<GameObject>();
    [SerializeField] private bool altarsActive;

    public GameObject starOn;
    public GameObject starOff;

    public bool levelPuzzle;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && altarsActive == true)
        {
            PlatformMove.Invoke();
        }
    }

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
            TurnStarOn();

            if (levelPuzzle == true)
            {
                PuzzleCompletion.Invoke();
            }

        } else
        {
            TurnStarOff();
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
