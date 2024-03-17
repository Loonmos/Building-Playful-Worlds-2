using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUp : MonoBehaviour
{
    public List<Transform> levelTransformsList = new List<Transform>(); // use this instead of separate transforms

    public Transform levelOne;
    public Transform levelTwo;
    public Transform levelThree;
    public Transform levelFour;

    public GameObject starOff;
    public GameObject starOn;

    public GameObject litAltarOne;
    public GameObject litAltarTwo;

    private bool pressed;
    [SerializeField] private bool onLevel1;
    [SerializeField] private bool onLevel2;
    [SerializeField] private bool onLevel3;
    [SerializeField] private bool onLevel4;
    
    private float speed = 1f;

    void Start()
    {
        pressed = false;
        onLevel1 = true;
        onLevel2 = false;
        onLevel3 = false;
        onLevel4 = false;
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // use list for platform positions
        if (onLevel1 == true && litAltarOne.activeInHierarchy == true && litAltarTwo.activeInHierarchy == true) // turn wincondition into event
        {
            SetStarActive();

            if (pressed == true)
            {
                GoLevel2();
            }
        }
        else if (onLevel2 == true)
        {
            SetStarActive();

            if (pressed == true)
            {
                GoLevel3();
            }
        }
        else if (onLevel3 == true)
        {
            SetStarActive();

            if (pressed == true)
            {
                GoLevel4();
            }
        }
        else if (onLevel4 == true)
        {
            SetStarActive();

            if (pressed == true)
            {
                GoLevel1();
            }
        }
        else
        {
            SetStarInactive();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pressed = true;
        }
    }

    void SetStarActive()
    {
        starOff.SetActive(false);
        starOn.SetActive(true);
    }

    void SetStarInactive()
    {
        starOff.SetActive(true);
        starOn.SetActive(false);
    }

    void GoLevel1()
    {
        //transform.position = Vector3.MoveTowards(transform.position, levelTransformsList[levelIndex].position, speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, levelOne.position, speed * Time.deltaTime);

        if (transform.position == levelOne.position)
        {
            onLevel4 = false;
            onLevel1 = true;
            pressed = false;
        }
    }

    void GoLevel2()
    {
        transform.position = Vector3.MoveTowards(transform.position, levelTwo.position, speed * Time.deltaTime);

        if (transform.position == levelTwo.position)
        {
            onLevel1 = false;
            onLevel2 = true;
            pressed = false;
            SetStarInactive();
        }
    }

    void GoLevel3()
    {
        transform.position = Vector3.MoveTowards(transform.position, levelThree.position, speed * Time.deltaTime);

        if (transform.position == levelThree.position)
        {
            onLevel2 = false;
            onLevel3 = true;
            pressed = false;
            SetStarInactive();
        }
    }

    void GoLevel4()
    {
        transform.position = Vector3.MoveTowards(transform.position, levelFour.position, speed * Time.deltaTime);

        if (transform.position == levelFour.position)
        {
            onLevel3 = false;
            onLevel4 = true;
            pressed = false;
            SetStarInactive();
        }
    }
}
