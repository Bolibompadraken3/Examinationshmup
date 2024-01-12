using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject projectilePrefab;  // Prefab of the projectile to be shot
    public Transform shootingPoint;      // Point where the projectile is spawned
    public float shootingInterval = 2f;  // Interval between shots
    public float projectileSpeed = 10f;  // Speed of the projectiles

    private Transform player;

    void Start()
    {
        // Find the player in the scene (you might want to optimize this based on your game structure)
        player = FindObjectOfType<ShipController>().transform;

        if (player == null)
        {
            Debug.LogError("Player not found in the scene. Make sure the PlayerController script is attached to the player.");
        }

        // Start shooting repeatedly
        InvokeRepeating("ShootAtPlayer", 0f, shootingInterval);
    }

    void ShootAtPlayer()
    {
        if (player != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 directionToPlayer = (player.position - shootingPoint.position).normalized;

            // Instantiate a projectile and set its direction and speed
            GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);
            projectile.GetComponent<ProjectileController>().SetDirection(directionToPlayer * projectileSpeed);
        }
    }
}
