using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public LayerMask enemyLayer; // Define the enemy layer in the Inspector.
    public float damageAmount = 10f; // Amount of damage to apply on collision.
    public float cooldownDuration = 1f; // Cooldown duration in seconds.
    public UIController uiController;
    public CharacterController controller;
    public Animator animator; // Reference to the character's Animator component.

    private bool canDamage = true; // Flag to control cooldown.
    private float cooldownTimer = 0f; // Timer to track cooldown.

    private void Update()
    {
        // Check if the cooldown has expired.
        Debug.Log(IsRolling());
        if (!canDamage)
        {
            cooldownTimer += Time.deltaTime;

            // If the cooldown timer reaches or exceeds the cooldown duration, reset the flag.
            if (cooldownTimer >= cooldownDuration)
            {   
                canDamage = true;
                cooldownTimer = 0f; // Reset the timer.
            }
        }

        // Check for collisions and apply damage only if the cooldown allows and not in the roll animation.
        if (canDamage && Physics.CheckSphere(transform.position, 0.5f, enemyLayer) && !IsRolling())
        {
            // Apply damage to the object equal to the damageAmount variable.
            uiController.health -= damageAmount;

            // Set the flag to false to initiate cooldown.
            canDamage = false;
        }
    }

    private bool IsRolling()
    {
        // Check if the character is in the roll animation.
        // You need to set up the appropriate trigger or parameter name in your Animator.
        return animator.GetBool("isRolling");
    }
}
