using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueStates : MonoBehaviour
{
    private GameManager gameManager;
    public Animator anim;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        if (gameManager.levelCompleted == true)
        {
            anim.SetBool("Activated", true);
        }
        else
        {
            anim.SetBool("Activated", false);
        } 
    }

    public void StatueActivation()
    {
        anim.SetBool("Activated", true);
    }
}
