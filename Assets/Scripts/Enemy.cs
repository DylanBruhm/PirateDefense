using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private Waypoints Wpoints;
    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position ) < 0.1f)
        {
            waypointIndex++;
        }
    }
}
