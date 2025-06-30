using System.Collections; 
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Vector2 _lastDirection;

    public void SetLastDirection(Vector2 dir)
    {
        _lastDirection = dir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Move the player one step back in the opposite direction
            transform.position = (Vector2)transform.position - _lastDirection;
        }
    }
}

