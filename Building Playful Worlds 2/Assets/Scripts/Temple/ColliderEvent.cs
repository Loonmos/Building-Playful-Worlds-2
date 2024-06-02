using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEvent : MonoBehaviour
{
    public UnityEvent Collided;

    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Collided.Invoke();
    }

    public void SaveGame()
    {
        gameManager.SaveGameTemple();
    }

}
