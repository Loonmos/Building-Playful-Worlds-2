using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AltarActivation : MonoBehaviour
{
    public UnityEvent ActivatedEvent;
    public UnityEvent CheckAltarEvent;

    public GameObject lightPathOff;
    public GameObject lightPathOn;

    public GameObject lightCrystalOff;
    public GameObject lightCrystalOn;

    public float pathValue;
    public float crystalValue;
    [SerializeField] private float valueCount;

    public AudioSource activateSound;

    void Start()
    {
        lightPathOff.SetActive(true);
        lightPathOn.SetActive(false);

        lightCrystalOff.SetActive(true);
        lightCrystalOn.SetActive(false);

        valueCount = 0;
    }


    void Update()
    {

    }

    public void ActivatePath() // if value = smt activate lightpath
    {
        if (valueCount >= pathValue)
        {
            PathOn();
        }
        else
        {
            PathOff();
        }
    }

    public void ActivateCrystal() // if value = smt activate lightcrystal
    {
        if (valueCount >= crystalValue)
        {
            CrystalOn();
            activateSound.Play();
            ActivatedEvent.Invoke();
            CheckAltarEvent.Invoke();
        }
        else
        {
            CrystalOff();
            CheckAltarEvent.Invoke();
        }
    }

    public void AddToCount(float addition)
    {
        valueCount = valueCount + addition;
        
        ActivatePath();
        ActivateCrystal();
    }

    public void ResetCount()
    {
        valueCount = 0;

        ActivatePath();
        ActivateCrystal();
    }

    public void RemoveFromCount(float subtraction)
    {
        valueCount = valueCount - subtraction;

        ActivatePath();
        ActivateCrystal();
    }

    public void CrystalOn()
    {
        lightCrystalOff.SetActive(false);
        lightCrystalOn.SetActive(true);
    }

    public void CrystalOff()
    {
        lightCrystalOff.SetActive(true);
        lightCrystalOn.SetActive(false);
    }

    public void PathOn()
    {
        lightPathOff.SetActive(false);
        lightPathOn.SetActive(true);
    }

    public void PathOff()
    {
        lightPathOff.SetActive(true);
        lightPathOn.SetActive(false);
    }
}
