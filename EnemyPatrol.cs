using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float speed = 10f;

    private const float SQR_EPSILON = 1f;
    private int currentTarget;
    private Rigidbody2D enemyBody;

    private void Start()
    {
        currentTarget = 0;
        enemyBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float d = Vector3.Distance(points[currentTarget].position, transform.position);
        //Debug.Log(d);

        if (d < SQR_EPSILON)
        {
            currentTarget++;
            currentTarget %= points.Length;
            //Debug.Log("Current target: " + currentTarget);
        }

        Vector3 direction = points[currentTarget].position - transform.position;
        direction.y = 0;
        direction.Normalize();
        enemyBody.velocity = direction * speed;
        //enemyBody.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }
}
