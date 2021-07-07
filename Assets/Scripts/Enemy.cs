using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    // waypoints from script for enemy to follow
    private Waypoints Wpoints;
    // to check what waypoint enemy is on
    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        // look for object with the tag and get the scrpit
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    // Update is called once per frame
    void Update()
    {
        //moves the enemy to the waypoints
        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

        // changes the angle of the enemy to face the right direction
        Vector3 dir = Wpoints.waypoints[waypointIndex].position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // if the enemy reaches the last waypoint the enemy stops
        if(Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position ) < 0.1f)
        {
        if(waypointIndex < Wpoints.waypoints.Length - 1)
        {
            waypointIndex++;

        }
            else
            {
                speed = 0;
            }
        }
    }
}
