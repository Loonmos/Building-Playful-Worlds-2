using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpInPlace : MonoBehaviour
{
    public UnityEvent pickUp;

    public GameObject lightPathOff;
    public GameObject lightPathOn;
    
    public GameObject lightCrystalOff;
    public GameObject lightCrystalOn;

    public GameObject platformOn;
    public GameObject platformOff;

    public bool bigColliding;
    public bool smallColliding;

    void Start()
    {
        lightPathOn.SetActive(false);
        lightCrystalOn.SetActive(false);

        lightPathOff.SetActive(true);
        lightCrystalOff.SetActive(true);

        platformOff.SetActive(false);
        platformOn.SetActive(true);

        bigColliding = false;
        smallColliding = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BigPickUp" || other.tag == "Player")
        {
            lightPathOn.SetActive(true);
            lightCrystalOn.SetActive(true);

            lightPathOff.SetActive(false);
            lightCrystalOff.SetActive(false);

            platformOff.SetActive(true);
            platformOn.SetActive(false);

            pickUp.Invoke();
        }

        if (other.tag == "SmallPickUp")
        {
            lightPathOn.SetActive(true);
            lightPathOff.SetActive(false);

            platformOff.SetActive(true);
            platformOn.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BigPickUp" || other.tag == "Player")
        {
            lightPathOn.SetActive(false);
            lightCrystalOn.SetActive(false);

            lightPathOff.SetActive(true);
            lightCrystalOff.SetActive(true);

            platformOff.SetActive(false);
            platformOn.SetActive(true);

            pickUp.Invoke();
        }

        if (other.tag == "SmallPickUp")
        {
            lightPathOn.SetActive(false);
            lightPathOff.SetActive(true);

            platformOff.SetActive(false);
            platformOn.SetActive(true);
        }
    }

    void BigPickUp()
    {
        if (bigColliding == true)
        {
            lightPathOn.SetActive(true);
            lightCrystalOn.SetActive(true);

            lightPathOff.SetActive(false);
            lightCrystalOff.SetActive(false);

            platformOff.SetActive(true);
            platformOn.SetActive(false);
        }
        else if (bigColliding == false)
        {
            lightPathOn.SetActive(false);
            lightCrystalOn.SetActive(false);

            lightPathOff.SetActive(true);
            lightCrystalOff.SetActive(true);

            platformOff.SetActive(false);
            platformOn.SetActive(true);
        }
    }

    void SmallPickUp()
    {
        if (smallColliding == true)
        {
            lightPathOn.SetActive(true);
            lightPathOff.SetActive(false);

            platformOff.SetActive(true);
            platformOn.SetActive(false);
        }
        else if (smallColliding == false)
        {
            lightPathOn.SetActive(false);
            lightPathOff.SetActive(true);

            platformOff.SetActive(false);
            platformOn.SetActive(true);
        }
    }
}
