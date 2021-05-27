using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3;
    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;
    Seeker seek;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        seek = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("UpdatePath",0f,0.5f);
        seek.StartPath(rb.position, target.position, OnPathComplete);
    }
    void UpdatePath()
    {
        if (seek.IsDone())
        {
            seek.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }
        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - (Vector2)rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < currentWayPoint)
        {
            currentWayPoint++;
        }

    }
}
