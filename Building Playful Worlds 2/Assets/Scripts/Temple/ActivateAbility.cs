using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAbility : MonoBehaviour
{
    private GameManager gameManager;
    public PlatformMovement platformMove;

    public GameObject player;
    public PlayerAbility playerAbility;
    public PlayerAudio playerAudio;
    public OpenTemple openDoors;
    
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        player = GameObject.FindWithTag("Player");
        playerAbility = player.GetComponent<PlayerAbility>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerAbility.TurnOnAbility();
            gameManager.templeCompleted = true;
            playerAudio.getAbility.Play();
            openDoors.OpenDoors();
        }
    }
}
