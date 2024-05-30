using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAbility : MonoBehaviour
{
    public GameObject player;
    public PlayerAbility playerAbility;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerAbility = player.GetComponent<PlayerAbility>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerAbility.TurnOnAbility();
        }
    }
}
