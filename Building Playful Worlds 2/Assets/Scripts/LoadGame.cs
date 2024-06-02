using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (gameManager.levelCompleted == true && sceneName == "Level1")
        {
            gameManager.LoadGameOutside();
        }

        if (gameManager.templeCompleted == true && sceneName == "Level1Puzzle")
        {
            gameManager.LoadGameTemple();
        }
        
    }
}
