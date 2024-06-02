using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private GameManager gameManager;

    public List<Transform> levelTransformsList = new List<Transform>(); // use this instead of separate transforms
    [SerializeField] private int levelIndex;

    private float speed = 2f;
    public bool continuousMovement;
    private bool startMoving;
    public bool canMove;

    public GameObject player;
    public Transform playerPos;

    public GameObject starOn;
    public GameObject starOff;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        if (gameManager.templeCompleted == true)
        {
            canMove = true;
            TurnStarOn();
        }
        else
        {
            canMove = false;
        }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && canMove == true)
        {
            TurnOnMovement();
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
                TurnOffMovement();
                StartCoroutine(cooldownMovement()); // cooldown for canMove
                player.transform.position = playerPos.position;
            }
        }
    }

    public void TurnOnMovement()
    {
        startMoving = true;
    }

    public void TurnOffMovement()
    {
        startMoving = false;
        TurnStarOff();
    }

    public void TurnOnContinuous()
    {
        continuousMovement = true;
    }

    public void TurnStarOn()
    {
        starOn.SetActive(true);
        starOff.SetActive(false);
    }

    public void TurnStarOff()
    {
        starOn.SetActive(false);
        starOff.SetActive(true);
    }

    IEnumerator cooldownMovement()
    {
        canMove = false;
        TurnStarOff();

        yield return new WaitForSeconds(3);

        canMove = true;
        TurnStarOn();
    }
}
