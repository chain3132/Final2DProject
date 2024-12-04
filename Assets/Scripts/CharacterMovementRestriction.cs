using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementRestriction : MonoBehaviour
{
    public float speed = 2f;  // Movement speed
    private Vector2 randomDirection; // Current direction
    private Collider2D boundary;

    
    void Start()
    {
        // Find the boundary collider
        boundary = GameObject.FindWithTag("Boundary").GetComponent<Collider2D>();
        randomDirection = GetRandomDirection();
        StartCoroutine(ChangeDirectionPeriodically());
    }

    void Update()
    {
        if (boundary != null)
        {
            Vector3 movement = randomDirection * speed * Time.deltaTime;
            transform.position += movement;
            
            // Clamp player's position to the boundary
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(transform.position.x, boundary.bounds.min.x, boundary.bounds.max.x);
            clampedPosition.y = Mathf.Clamp(transform.position.y, boundary.bounds.min.y, boundary.bounds.max.y);
            transform.position = clampedPosition;
            
            // Reverse direction if hitting boundary
            if (transform.position.x == boundary.bounds.min.x || transform.position.x == boundary.bounds.max.x)
                randomDirection.x *= -1;
            if (transform.position.y == boundary.bounds.min.y || transform.position.y == boundary.bounds.max.y)
                randomDirection.y *= -1;
        }
    }
    private Vector2 GetRandomDirection()
    {
        // Generate a random direction vector
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        return new Vector2(randomX, randomY).normalized;
    }

    private IEnumerator ChangeDirectionPeriodically()
    {
        while (true)
        {
            // Change direction every 1-3 seconds randomly
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            randomDirection = GetRandomDirection();
        }
    }
}
