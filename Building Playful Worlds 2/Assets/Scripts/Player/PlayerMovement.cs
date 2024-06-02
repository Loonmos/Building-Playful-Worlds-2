using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public GravityText gravText;

    [SerializeField] private float speed = 12f;
    
    [SerializeField] private float scroll = 0;
    public float scrollValue;
    public bool canChangeGravSelf;
    
    Vector3 velocity;
    public float gravity = -19.62f;
    
    public float jumpHeight = 3f;
    public int jumpUses = 1;
    public float jumpResetCooldown;
    private bool canReset;

    public Transform groundCheck;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public LayerMask shroomMask;
    bool isShroomed;

    public Transform starCrystal;
    public Transform starRegular;
    public Transform starCastSelf;

    private bool useAbility;

    public TextMeshProUGUI velocityText;

    public UnityEvent TouchGround;

    void Start()
    {
        gravity = -20f;
        useAbility = true;
        canReset = true;
        canChangeGravSelf = true;
    }

    void Update()
    {
        CheckGround();
        CheckShroom();

        MovePlayer();
        ApplyGravity(gravity);

        if (canChangeGravSelf == true)
        {
            ChangeGravSelf();
        }
        
        if (Input.GetButtonDown("Jump") && jumpUses >= 1)
            {
                Jump(gravity);
            }

        //if (Input.GetButton("FocusSelf"))
        //{
        //    starCrystal.position = starCastSelf.position;
        //    if (useAbility == true)
        //    {
        //        FocusSelf();
        //    }
        //}
        
        //if (Input.GetButtonUp("FocusSelf"))
        //{
        //    starCrystal.position = starRegular.position;
        //}
    }

    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // checks if player is on ground

        if (isGrounded && velocity.y < 0) // resets velocity when player is grounded
        {
            velocity.y = -2f;
        }

        if (isGrounded)
        {
            if (canReset == true)
            {
                jumpUses = 1;
            }
            TouchGround.Invoke();
        }
    }

    void CheckShroom()
    {
        isShroomed = Physics.CheckSphere(groundCheck.position, groundDistance, shroomMask); // checks if player hits the shroom

        if (isShroomed)
        {
            velocity.y = -velocity.y;
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
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * grav);
        jumpUses -= 1;
        StartCoroutine(JumpCooldown());
    }

    IEnumerator JumpCooldown()
    {
        canReset = false;

        yield return new WaitForSeconds(jumpResetCooldown);

        canReset = true;
    }

    void ApplyGravity(float grav)
    {
        velocity.y += grav * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void ChangeGravSelf()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            scroll += scrollValue;
            // change starcrystal pos
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            scroll -= scrollValue;
            // change starcrystal pos
        }

        if (scroll >= 1)
        {
            scroll = 1;
            ChangeGravity(-30f, 6f, 1f);
            gravText.ChangeText("high");
        }

        if (scroll == 0)
        {
            ChangeGravity(-20f, 12f, 3f);
            gravText.ChangeText("normal");
        }

        if (scroll <= -1)
        {
            scroll = -1;
            ChangeGravity(-10f, 18f, 5f);
            gravText.ChangeText("low");
        }
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
