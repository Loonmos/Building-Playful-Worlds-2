using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosOnStart : MonoBehaviour
{
    private GameObject player;
    private CharacterController charContoller;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        charContoller = player.GetComponent<CharacterController>();

        charContoller.enabled = false;
        player.transform.position = transform.position;
        charContoller.enabled = true;
    }
}
