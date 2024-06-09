using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource walk;
    public AudioSource run;
    public AudioSource lowGrav;
    public AudioSource normalGrav;
    public AudioSource highGrav;
    public AudioSource abilityStar;
    public AudioSource abilityPlayer;
    public AudioSource getAbility;
    public AudioSource pickUpCrystal;
    public AudioSource pickUpVase;
    public AudioSource insert;
    public AudioSource barrier;
    public AudioSource bounce;

    public bool onGround;

    public bool walking;
    private bool walkPlaying;

    public bool running;
    private bool runPlaying;

    public bool moving;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (onGround == true && moving == true)
        {
            if (walking == true && walkPlaying == false)
            {
                run.Stop();
                runPlaying = false;

                StartCoroutine(Walking());
            }

            if (running == true && runPlaying == false)
            {
                walk.Stop();
                walkPlaying = false;

                StartCoroutine(Running());
            }
        }
        if (onGround == false || moving == false)
        {
            walk.Stop();
            run.Stop();
            walkPlaying = false;
            runPlaying = false;
        }

        
    }

    IEnumerator Walking()
    {
        walkPlaying = true;

        float length = walk.clip.length;

        walk.Play();
        yield return new WaitForSeconds(length);

        walkPlaying = false;
    }

    IEnumerator Running()
    {
        runPlaying = true;

        float length = walk.clip.length;

        run.Play();
        yield return new WaitForSeconds(length);

        runPlaying = false;
    }
}
