using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask playerLayer; // Define the player layer in the Inspector.
    public float contactDamage = 10f; // Amount of damage dealt on contact with the player.
    public float maxHealth = 20; // Maximum health of the enemy.

    private float currentHealth; // Current health of the enemy.

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health.
    }

    private void Update(){
        if(Physics.CheckSphere(transform.position, 0.5f, playerLayer)){
            currentHealth -= contactDamage;
        }
        if(currentHealth <= 0){
            Die();
        }
    }


    private void Die()
    {
        // Perform any death-related actions here, e.g., play death animation, particle effects, etc.

        // Destroy the enemy object.
        Destroy(gameObject);
    }
}
