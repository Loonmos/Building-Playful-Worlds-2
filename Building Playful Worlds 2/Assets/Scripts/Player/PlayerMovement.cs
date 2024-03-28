using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public GravityText gravText;

    [SerializeField] private float speed = 12f;
    Vector3 velocity;
    public float gravity = -19.62f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public Transform starCrystal;
    public Transform starRegular;
    public Transform starCastSelf;

    private bool useAbility;

    void Start()
    {
        gravity = -20f;
        useAbility = true;
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
            if (useAbility == true)
            {
                FocusSelf();
            }
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
            ChangeGravity(-10f, 18f, 5f);
            gravText.ChangeText("low");
        }
        
        if (Input.GetButtonDown("NormalG"))
        {
            ChangeGravity(-20f, 12f, 3f);
            gravText.ChangeText("normal");
        }
        
        if (Input.GetButtonDown("HighG"))
        {
            ChangeGravity(-30f, 6f, 1f);
            gravText.ChangeText("high");
        }
    }

    public void TurnAbilityOnAndOff()
    {
        useAbility = !useAbility;
    }

    void ChangeGravity(float grav, float sp, float jump)
    {
        gravity = grav;
        speed = sp;
        jumpHeight = jump;
    }
}
