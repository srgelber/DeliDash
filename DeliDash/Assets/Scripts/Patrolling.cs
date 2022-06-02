using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=22PZJlpDkPE&ab_channel=KeySmashStudios

public class Patrolling : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;

    private int waypointIndex;
    private float dist;
    private bool isPatrolling = true;

    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;   
        //transform.LookAt(waypoints[waypointIndex].position);
    }

    void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (dist < 1f)
        {
            IncreaseIndex();
        }

        if(isPatrolling)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
        //isPatrolling = false;
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        //transform.LookAt(waypoints[waypointIndex].position);
    }

}
