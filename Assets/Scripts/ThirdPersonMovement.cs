using System.Collections;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator animator;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;
    public float rollCooldown = 1.5f;
    public float attackCooldown = 1.0f; // Adjust as needed
    
    private float turnSmoothVelocity;
    private Vector3 velocity;
    private float rollCooldownTimer;
    private float attackCooldownTimer; // Timer for attack cooldown

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        HandleMovement(direction);
        HandleRoll();
        HandleAttack();
    }

    private void HandleMovement(Vector3 direction)
    {
        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("isWalking", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleRoll()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1)) && Time.time > rollCooldownTimer)
        {
            animator.SetTrigger("roll");
            rollCooldownTimer = Time.time + rollCooldown;
        }
    }

    private void HandleAttack()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton2)) && Time.time > attackCooldownTimer)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Roll")) // Check if not in roll animation
            {
                animator.SetTrigger("attack");
                attackCooldownTimer = Time.time + attackCooldown;
            }
        }
    }

}
