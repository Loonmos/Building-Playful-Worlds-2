using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InsertCrystal : MonoBehaviour
{
    public UnityEvent Inserted;

    public PlayerInventory playerInventory;

    public GameObject crystal;
    private bool canInsert;

    // Start is called before the first frame update
    void Start()
    {
        crystal.SetActive(false);
        canInsert = true;
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
