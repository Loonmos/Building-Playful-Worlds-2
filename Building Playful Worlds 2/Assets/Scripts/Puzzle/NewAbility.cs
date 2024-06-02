using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAbility : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject particles;

    private float particleTime = 5f;
    private bool particlesActive;
    
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        if (gameManager.templeCompleted == true)
        {
            gameObject.SetActive(false);
        }

        particles.SetActive(false);
        particlesActive = false;
    }

    
    void Update()
    {
        
    }

    public void DestroyObject()
    {
        gameObject.SetActive(false);
    }

    public void ActivateParticles()
    {
        if (particlesActive == false)
        {
            StartCoroutine(ParticlesActive());
        } 
    }

    IEnumerator ParticlesActive()
    {
        particlesActive = true;
        particles.SetActive(true);

        yield return new WaitForSeconds(particleTime);

        particles.SetActive(false);
    }
}
