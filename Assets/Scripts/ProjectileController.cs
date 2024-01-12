using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction;

    // Set the initial direction of the projectile
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }

    void Update()
    {
        // Move the projectile in the set direction
        transform.Translate(direction * speed * Time.deltaTime);

        // Destroy the projectile if it goes off-screen
        if (!IsOnScreen())
        {
            Destroy(gameObject);
        }
    }

    bool IsOnScreen()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return screenPosition.x > 0 && screenPosition.x < Screen.width && screenPosition.y > 0 && screenPosition.y < Screen.height;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the projectile collides with an enemy
        if (other.CompareTag("Enemy"))
        {
            // Deal damage to the enemy (adjust this part based on your game logic)
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(); // Assuming you have a TakeDamage method in your EnemyController
            }

            // Award points for hitting an enemy
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(enemyController.pointsForDefeat); // Assuming pointsForDefeat is a public variable in EnemyController
            }

            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}
