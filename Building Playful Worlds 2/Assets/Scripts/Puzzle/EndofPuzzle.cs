using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndofPuzzle : MonoBehaviour
{
    public UnityEvent endOfTemple;

    public GameObject endScreen;

    private float endQuit = 60;
    
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
        StartCoroutine(EndingQuit());
    }

    IEnumerator EndingQuit()
    {
        yield return new WaitForSeconds(endQuit);

        Time.timeScale = 0;
        endScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
