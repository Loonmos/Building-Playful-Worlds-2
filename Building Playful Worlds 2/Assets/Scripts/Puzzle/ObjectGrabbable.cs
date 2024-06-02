using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Transform objectGrabPoint;
    public CharacterController controller;

    public GameObject objectNorm;
    public GameObject objectLow;
    public GameObject objectHigh;

    private float lerpSpeed = 10f;
    public float gravity;
    Vector3 velocity;

    bool isGrounded;
    public Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool canChangeGravity;

    private void Start()
    {
        gravity = -20f;

        objectNorm.SetActive(true);
        objectLow.SetActive(false);
        objectHigh.SetActive(false);

        canChangeGravity = true;
    }

    private void Update()
    {
        if (objectGrabPoint != null)
        {
            Vector3 newPos = Vector3.Lerp(transform.position, objectGrabPoint.position, Time.deltaTime * lerpSpeed);
            transform.position = newPos;
        }
        else
        {
            Ground();
            ApplyGravity(gravity);
        }
    }

    public void Grab(Transform objectGrabPoint)
    {
        this.objectGrabPoint = objectGrabPoint;
    }

    public void Drop()
    {
        this.objectGrabPoint = null;
    }

    void Ground()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // checks if on ground

        if (isGrounded && velocity.y < 0) // resets velocity when grounded
        {
            velocity.y = -2f;
        }
    }

    void ApplyGravity(float grav)
    {
        velocity.y += grav * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void ChangeObjGravity()
    {
        if (canChangeGravity == true)
        {
            //if (Input.GetButtonDown("LowG"))
            //{
            //    ChangeGravity(-10f);
            //    objectNorm.SetActive(false);
            //    objectLow.SetActive(true);
            //    objectHigh.SetActive(false);
            //}

            //if (Input.GetButtonDown("NormalG"))
            //{
            //    ChangeGravity(-20f);
            //    objectNorm.SetActive(true);
            //    objectLow.SetActive(false);
            //    objectHigh.SetActive(false);
            //}

            //if (Input.GetButtonDown("HighG"))
            //{
            //    ChangeGravity(-30f);
            //    objectNorm.SetActive(false);
            //    objectLow.SetActive(false);
            //    objectHigh.SetActive(true);
            //}
        }
        
    }

    public void SetGravLow()
    {
        ChangeGravity(-10f);
        objectNorm.SetActive(false);
        objectLow.SetActive(true);
        objectHigh.SetActive(false);
    }

    public void SetGravNormal()
    {
        ChangeGravity(-20f);
        objectNorm.SetActive(true);
        objectLow.SetActive(false);
        objectHigh.SetActive(false);
    }

    public void SetGravHigh()
    {
        ChangeGravity(-30f);
        objectNorm.SetActive(false);
        objectLow.SetActive(false);
        objectHigh.SetActive(true);
    }

    public void CanChangeGravityOnAndOff()
    {
        canChangeGravity = !canChangeGravity;
    }

    void ChangeGravity(float grav)
    {
        gravity = grav;
    }
}
