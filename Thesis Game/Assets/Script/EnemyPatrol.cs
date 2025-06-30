using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PointB.transform;
        anim.SetBool("IsRunning", true);
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;

        if (currentPoint == PointB.transform)
        {
            rb.linearVelocity = new Vector2(0, speed);
            Debug.Log("Moving up");
        }
        else
        {
            rb.linearVelocity = new Vector2(0, -speed);
            Debug.Log("Moving down");
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform)
        {
            currentPoint = PointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            currentPoint = PointB.transform;
        }
    }

    private void OnDrawGizmos()
    {
        if (PointA != null && PointB != null)
        {
            Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
            Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);
            Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
        }
    }
}
