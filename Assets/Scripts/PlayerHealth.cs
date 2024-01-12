using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Add more logic as needed, e.g., checking for death
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implement player death logic here
        Debug.Log("Player has died!");
    }
}
