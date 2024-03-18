using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public UnityEvent PlatformMove;

    public List<GameObject> altarList = new List<GameObject>();
    [SerializeField] private bool altarsActive;
    
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
    }
}
