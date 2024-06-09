using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueSlam : MonoBehaviour
{
    public AudioSource source;
    public AudioClip slam;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Slam()
    {
        Debug.Log("slam");
        //source.PlayOneShot(slam);
        source.Play();
    }
}
