using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator animator;

    // Movement speed
    public float speed = 6f;

    // Smooth turning
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Gravity
    public float gravity = -9.81f;

    // Velocity
    Vector3 velocity;

    // Roll cooldown
    public float rollCooldown = 1.5f;
    [SerializeField] private float rollCooldownTimer = 1.75f;

    // Update is called once per frame
    void Update()
    {   

        // Get input from player
        float horizontal = Input.GetAxisRaw("Horizontal"); // A, D, Left, Right
        float vertical = Input.GetAxisRaw("Vertical"); // W, S, Up, Down
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // Normalized to prevent faster diagonal movement, and to ignore y-axis movement

        // Roll animation (space, or B button on controller to roll)
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1)) && Time.time > rollCooldown){
            animator.SetTrigger("roll");
            rollCooldownTimer = Time.time + rollCooldown;
        }

        // Animation & player controller
        // If moving, play walk animation, else play idle animation
        if(direction.magnitude >= 0.1f){
            animator.SetBool("isWalking", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // Angle in radians
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); // Smoothly rotate to target angle
            transform.rotation = Quaternion.Euler(0f, angle, 0f); // Rotate to target angle
            
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // Move in direction of target angle
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            // Gravity
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        } else {
            animator.SetBool("isWalking", false);
        }
    }
}
