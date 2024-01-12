using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public int maxEnemies = 10;

    private float nextSpawnTime;
    private bool canStartSpawning = false;
    private float startTime;

    // Specify the spawn area
    public Vector2 spawnAreaSize = new Vector2(6.5f, 0f);

    void Start()
    {
        // Record the start time
        startTime = Time.time;
    }

    void Update()
    {
        // Check if enough time has passed to start spawning
        if (Time.time - startTime >= 4f)
        {
            canStartSpawning = true;
        }

        // Start spawning if allowed
        if (canStartSpawning && Time.time > nextSpawnTime && CountEnemies() < maxEnemies)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        // Generate a random spawn position within the specified area
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnAreaSize.x / 10f, spawnAreaSize.x / 14.5f),
            Random.Range(-spawnAreaSize.y / -3f, spawnAreaSize.y / -2.5f),
            0f
        );

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    int CountEnemies()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}
