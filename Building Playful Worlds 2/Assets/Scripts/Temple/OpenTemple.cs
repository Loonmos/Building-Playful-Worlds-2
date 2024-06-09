using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenTemple : MonoBehaviour
{
    private GameManager gameManager;
    public List<GameObject> crystalList = new List<GameObject>();
    [SerializeField] private bool crystalsActive;
    public AudioSource sound;

    public Animator anim1;
    public Animator anim2;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (gameManager.levelCompleted == true && sceneName == "Level1" || gameManager.templeCompleted == true && sceneName == "Level1Puzzle")
        {
            anim1.SetBool("Open", true);
            anim2.SetBool("Open", true);
        }
        else
        {
            anim1.SetBool("Open", false);
            anim2.SetBool("Open", false);
        } 
    }

    public void OpenDoors()
    {
        anim1.SetBool("Open", true);
        anim2.SetBool("Open", true);
        sound.Play();
    }

    public void CheckCrystals()
    {
        foreach (GameObject crystal in crystalList)

            if (crystal.activeInHierarchy == false)
            {
                crystalsActive = false;
                break;
            }
            else
            {
                crystalsActive = true;
            }

        if (crystalsActive == true)
        {
            OpenDoors();
            gameManager.levelCompleted = true;
        }
    }
}
