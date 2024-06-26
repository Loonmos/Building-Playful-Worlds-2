using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAbility : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject particles;
    public GameObject detroyThis;

    private float particleTime = 3;
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
        detroyThis.SetActive(false);
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
        Debug.Log("active");

        yield return new WaitForSeconds(3);

        Debug.Log("inactive");
        particles.SetActive(false);
    }
}
