using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueStates : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim.SetBool("Activated", false);
    }

    public void StatueActivation()
    {
        anim.SetBool("Activated", true);
    }
}
