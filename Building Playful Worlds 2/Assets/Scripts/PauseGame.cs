using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseScreen;
    public PlayerMovement playerMove;
    public GameObject gravScreens;

    void Start()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }

    
    void Update()
    {
        // if escape if pressed, open pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        playerMove.enabled = false;
        gravScreens.SetActive(false);
    }

    public void UnPause()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        playerMove.enabled = true;
        gravScreens.SetActive(true);
    }
}
