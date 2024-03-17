using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public Transform cam;
    public Rigidbody rb;

    [SerializeField] float speed;
    [SerializeField] bool onGround;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 direction;
    Vector3 jump;

    void Start()
    {
        
    }

    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Move", direction.sqrMagnitude);
        animator.SetFloat("Speed", speed);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);

            if (Input.GetButton("LeftShift"))
            {
                speed = 7f;
            }
            else
            {
                speed = 3f;
            }
        }

        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            jump = new Vector3(0, 5, 0);
            //rb.AddForce(jump, ForceMode.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }
}
