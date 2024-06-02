using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InsertCrystal : MonoBehaviour
{
    public UnityEvent Inserted;

    private GameManager gameManager;
    public PlayerInventory playerInventory;

    public GameObject crystal;
    private bool canInsert;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        if (gameManager.levelCompleted == true)
        {
            crystal.SetActive(true);
            canInsert = false;
        }
        else
        {
            crystal.SetActive(false);
            canInsert = true;
        }
    }

    public void CrystalInserted()
    {
        if (canInsert == true && playerInventory.crystalAmount >= 1)
        {
            crystal.SetActive(true);
            playerInventory.RemoveCrystal();
            canInsert = false;
            Inserted.Invoke();
        }
    }
}
