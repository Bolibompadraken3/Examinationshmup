using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public int bulletsToDestroy = 5;
    public int damage = 10;
    public int pointsForDefeat = 10;

    private int bulletsHit = 0;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        MoveLeft();
    }

    void MoveLeft()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            bulletsHit++;
            Destroy(collision.gameObject);

            if (bulletsHit >= bulletsToDestroy)
            {
                TakeDamage();
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }

    public void TakeDamage()
    {
        // Add any additional logic for enemy damage here
        // For example, you might reduce the enemy's health or play a damage animation
    }
}
