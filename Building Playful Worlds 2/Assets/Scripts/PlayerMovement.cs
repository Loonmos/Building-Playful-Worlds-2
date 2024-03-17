using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    [SerializeField] private float speed = 12f;
    Vector3 velocity;
    public float gravity = -19.62f;
    [SerializeField] private float mass = 60;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public GameObject lowG;
    public GameObject highG;

    public Transform starCrystal;
    public Transform starRegular;
    public Transform starCastSelf;

    void Start()
    {
        gravity = -20f;
        lowG.SetActive(false);
        highG.SetActive(false);
    }

    void Update()
    {
        Ground();

        MovePlayer();
        Jump(gravity);
        ApplyGravity(gravity);

        if (Input.GetButton("FocusSelf"))
        {
            starCrystal.position = starCastSelf.position;
            FocusSelf();
        }
        else if (!Input.GetButton("FocusOther"))
        {
            starCrystal.position = starRegular.position;
        }
    }

    void Ground()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // checks if player is on ground

        if (isGrounded && velocity.y < 0) // resets velocity when player is grounded
        {
            velocity.y = -2f;
        }
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetButton("LeftShift")) // run
        {
            controller.Move(move * speed * 1.5f * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }
    }

    void Jump(float grav)
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * grav);
        }
    }

    void ApplyGravity(float grav)
    {
        velocity.y += grav * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void FocusSelf()
    {
        if (Input.GetButtonDown("LowG"))
        {
            ChangeGravity(-10f, 12f, 5f, true, false);
        }
        
        if (Input.GetButtonDown("NormalG"))
        {
            ChangeGravity(-20f, 6f, 3f, false, false);
        }
        
        if (Input.GetButtonDown("HighG"))
        {
            ChangeGravity(-30f, 3f, 1f, false, true);
        }
    }

    void ChangeGravity(float grav, float sp, float jump, bool low, bool high)
    {
        gravity = grav;
        speed = sp;
        jumpHeight = jump;

        lowG.SetActive(low);
        highG.SetActive(high);
    }
}
