using UnityEngine;

public class EnemyProjectileController : MonoBehaviour
{
    public float speed = 10f;  // Adjust the speed as needed

    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.right * speed * Time.deltaTime);

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
        // Destroy the projectile if it collides with something (player, obstacle, etc.)
        Destroy(gameObject);
    }
}
