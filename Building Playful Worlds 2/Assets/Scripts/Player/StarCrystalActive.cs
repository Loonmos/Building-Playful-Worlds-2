using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCrystalActive : MonoBehaviour
{
    public bool starActive;
    
    void Start()
    {
        this.gameObject.SetActive(starActive);
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
