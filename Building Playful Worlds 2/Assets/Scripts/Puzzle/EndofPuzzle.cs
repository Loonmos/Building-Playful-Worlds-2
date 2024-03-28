using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndofPuzzle : MonoBehaviour
{
    public GameObject endScreen;

    private float endTimer = 10;
    
    void Start()
    {
        Time.timeScale = 1;
        endScreen.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void StartTimer()
    {
        StartCoroutine(EndTimer());
    }

    IEnumerator EndTimer()
    {
        yield return new WaitForSeconds(endTimer);

        Time.timeScale = 0;
        endScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
