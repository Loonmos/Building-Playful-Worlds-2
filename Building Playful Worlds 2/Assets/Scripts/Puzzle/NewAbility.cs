using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAbility : MonoBehaviour
{
    public GameObject particles;

    private float particleTime = 5f;
    
    void Start()
    {
        particles.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void ActivateParticles()
    {
        StartCoroutine(ParticlesActive());
    }

    IEnumerator ParticlesActive()
    {
        particles.SetActive(true);

        yield return new WaitForSeconds(particleTime);

        particles.SetActive(false);
    }
}
