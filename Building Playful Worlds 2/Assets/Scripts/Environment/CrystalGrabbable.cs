using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalGrabbable : MonoBehaviour
{
    private PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
    }

    public void PickUpCrystal()
    {
        playerInventory.AddCrystal();
        gameObject.SetActive(false);
    }
}
