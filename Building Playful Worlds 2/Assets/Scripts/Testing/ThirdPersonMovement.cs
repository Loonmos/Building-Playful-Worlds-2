using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController charController;
    public Transform cam;
    public GravityText gravText;

    [SerializeField] private float speed = 12f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

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

        Move();
        ApplyGravity(gravity);

        if (canChangeGravSelf == true)
        {
            ChangeGravSelf();
        }

        if (Input.GetButtonDown("Jump") && jumpUses >= 1)
        {
            Jump(gravity);
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            if (Input.GetButton("LeftShift")) // run
            {
                charController.Move(moveDirection.normalized * speed * 1.5f * Time.deltaTime);
            }
            else
            {
                charController.Move(moveDirection.normalized * speed * Time.deltaTime);
            }    
        }
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

        charController.Move(velocity * Time.deltaTime);
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
