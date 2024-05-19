using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPickUp : MonoBehaviour
{
    ObjectGrabbable objectGrabbable;
    PlayerMovement playerMovement;
    GameObject player;

    public UnityEvent QuarterObjectAdd;
    public UnityEvent HalfObjectAdd;
    public UnityEvent OneObjectAdd;
    public UnityEvent TwoObjectAdd;

    public UnityEvent QuarterObjectRemove;
    public UnityEvent HalfObjectRemove;
    public UnityEvent OneObjectRemove;
    public UnityEvent TwoObjectRemove;

    public GameObject platformOn;
    public GameObject platformOff;

    public AudioSource enterClick;
    public AudioSource exitClick;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void Start()
    {
        platformOn.SetActive(true);
        platformOff.SetActive(false);
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) // check if player and what gravity they have
    {
        enterClick.Play();

        if (other.tag == "Player")
        {
            platformOn.SetActive(false);
            platformOff.SetActive(true);

            playerMovement.TurnAbilityOnAndOff(); // turn off the players ability to change their gravity

            if (playerMovement.gravity == -10)
            {
                HalfObjectAdd.Invoke();
            }

            if (playerMovement.gravity == -20)
            {
                OneObjectAdd.Invoke();
            }

            if (playerMovement.gravity == -30)
            {
                TwoObjectAdd.Invoke();
            }
        }

        if (other.tag == "BigPickUp") // check if big vase and what gravity they have
        {
            platformOn.SetActive(false);
            platformOff.SetActive(true);

            objectGrabbable = other.GetComponent<ObjectGrabbable>();
            objectGrabbable.CanChangeGravityOnAndOff(); // turn off the players ability to change this objects gravity

            if (objectGrabbable.gravity == -10)
            {
                HalfObjectAdd.Invoke();
            }

            if (objectGrabbable.gravity == -20)
            {
                OneObjectAdd.Invoke();
            }

            if (objectGrabbable.gravity == -30)
            {
                TwoObjectAdd.Invoke();
            }
        }

        if (other.tag == "SmallPickUp") // check if small vase and what gravity they have
        {
            platformOn.SetActive(false);
            platformOff.SetActive(true);

            objectGrabbable = other.GetComponent<ObjectGrabbable>();
            objectGrabbable.CanChangeGravityOnAndOff(); // turn off the players ability to change this objects gravity

            if (objectGrabbable.gravity == -10)
            {
                QuarterObjectAdd.Invoke();
            }

            if (objectGrabbable.gravity == -20)
            {
                HalfObjectAdd.Invoke();
            }

            if (objectGrabbable.gravity == -30)
            {
                OneObjectAdd.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        exitClick.Play();

        if (other.tag == "Player") // check if player and what gravity they have
        {
            platformOn.SetActive(true);
            platformOff.SetActive(false);

            playerMovement.TurnAbilityOnAndOff(); // turn on the players ability to change their gravity

            if (playerMovement.gravity == -10)
            {
                HalfObjectRemove.Invoke();
            }

            if (playerMovement.gravity == -20)
            {
                OneObjectRemove.Invoke();
            }

            if (playerMovement.gravity == -30)
            {
                TwoObjectRemove.Invoke();
            }
        }

        if (other.tag == "BigPickUp") // check if big vase and what gravity they have
        {
            platformOn.SetActive(true);
            platformOff.SetActive(false);

            objectGrabbable = other.GetComponent<ObjectGrabbable>();
            objectGrabbable.CanChangeGravityOnAndOff(); // turn on the players ability to change this objects gravity

            if (objectGrabbable.gravity == -10)
            {
                HalfObjectRemove.Invoke();
            }

            if (objectGrabbable.gravity == -20)
            {
                OneObjectRemove.Invoke();
            }

            if (objectGrabbable.gravity == -30)
            {
                TwoObjectRemove.Invoke();
            }
        }

        if (other.tag == "SmallPickUp") // check if small vase and what gravity they have
        {
            platformOn.SetActive(true);
            platformOff.SetActive(false);

            objectGrabbable = other.GetComponent<ObjectGrabbable>();
            objectGrabbable.CanChangeGravityOnAndOff(); // turn on the players ability to change this objects gravity

            if (objectGrabbable.gravity == -10)
            {
                QuarterObjectRemove.Invoke();
            }

            if (objectGrabbable.gravity == -20)
            {
                HalfObjectRemove.Invoke();
            }

            if (objectGrabbable.gravity == -30)
            {
                OneObjectRemove.Invoke();
            }
        }
    }
}
