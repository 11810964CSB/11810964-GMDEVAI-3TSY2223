using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    public GameObject[] waypoints;

    int currentWaypointIndex = 0;

    float speed = 5;
    float rotSpeed = 3;
    float accuracy = 1;
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (waypoints.Length == 0) return;
        GameObject currentWaypoint = waypoints[currentWaypointIndex];

        Vector3 lookAtGoal = new Vector3(currentWaypoint.transform.position.x, this.transform.position.y, currentWaypoint.transform.position.z);
        Vector3 direction = lookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
