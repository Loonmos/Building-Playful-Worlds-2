using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public List<Transform> levelTransformsList = new List<Transform>(); // use this instead of separate transforms
    [SerializeField] private int levelIndex;

    private float speed = 2f;
    public bool continuousMovement;
    private bool startMoving;

    public GameObject player;
    public Transform playerPos;

    public GameObject starOn;
    public GameObject starOff;

    void Start()
    {
        continuousMovement = false;
        startMoving = false;
        levelIndex = 1;
    }

    
    private void FixedUpdate()
    {
        if (startMoving == true)
        {
            MovePlatform();
        }
    }

    public void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, levelTransformsList[levelIndex].position, speed * Time.deltaTime);

        if (transform.position == levelTransformsList[levelIndex].position)
        {
            levelIndex += 1;
            if (levelIndex == levelTransformsList.Count)
            {
                levelIndex = 0;
            }

            if (continuousMovement == false)
            {
                startMoving = false;
                player.transform.position = playerPos.position;
                TurnStarOff();
            }
        }
    }

    public void TurnOnMovement()
    {
        startMoving = true;
    }

    public void TurnOnContinuous()
    {
        continuousMovement = true;
    }

    public void TurnStarOff()
    {
        starOn.SetActive(false);
        starOff.SetActive(true);
    }
}
