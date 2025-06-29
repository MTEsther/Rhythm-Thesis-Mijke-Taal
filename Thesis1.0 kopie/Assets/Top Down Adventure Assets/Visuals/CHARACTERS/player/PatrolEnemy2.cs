using UnityEngine;

public class PatrolEnemy2 : MonoBehaviour
{
    [SerializeField] private Transform Enemy;
    [SerializeField] private Transform MovingToLocation;
    public float speed = 2f;

    private Vector3 pointA;
    private Vector3 pointB;
    private Vector3 nextPoint;
    private bool facingRight = false;

    void Start()
    {
        pointA = Enemy.position;                 // World position
        pointB = MovingToLocation.position;      // World position
        nextPoint = pointB;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Enemy.position = Vector3.MoveTowards(Enemy.position, nextPoint, speed * Time.deltaTime);

        if (Vector3.Distance(Enemy.position, nextPoint) < 0.1f)
        {
            nextPoint = nextPoint == pointA ? pointB : pointA;
            FlipEnemy();
        }
    }

    private void FlipEnemy()
    {
        facingRight = !facingRight;
        Vector3 scale = Enemy.localScale;
        scale.x *= -1;
        Enemy.localScale = scale;
    }
}
