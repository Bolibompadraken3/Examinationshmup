using UnityEngine;

public class ShootingSpawner : MonoBehaviour
{
    public GameObject shootingEnemyPrefab;  // Prefab of the shooting enemy
    public float spawnInterval = 5f;        // Interval between enemy spawns

    void Start()
    {
        // Start spawning enemies repeatedly after a delay
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Instantiate a shooting enemy at the spawner's position
        Instantiate(shootingEnemyPrefab, transform.position, Quaternion.identity);
    }
}
