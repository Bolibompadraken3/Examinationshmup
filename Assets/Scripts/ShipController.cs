using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    private float shotDelay = 0.1f;
    private float nextShotTime = 0f;

    void Update()
    {
        HandleMovementInput();
        HandleShootingInput();
    }

    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        movement.Normalize();

        transform.Translate(movement * speed * Time.deltaTime);

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -16f, 16f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -5f, 5);
        transform.position = clampedPosition;
    }

    void HandleShootingInput()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextShotTime)
        {
            Shoot();
            nextShotTime = Time.time + shotDelay;
        }
    }

    void Shoot()
    {
        // Instantiate a projectile at the spawn point
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

        // Set the projectile's direction
        ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
        if (projectileController != null)
        {
            projectileController.SetDirection(Vector3.right); // Set the direction to the ship's local right
        }
    }
}
