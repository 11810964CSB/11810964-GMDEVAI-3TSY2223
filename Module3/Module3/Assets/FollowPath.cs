using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Transform goal;
    float speed = 12.0f;
    float accuracy = 1.0f;
    float rotSpeed = 4.0f;
    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWaypointIndex = 0;
    Graph graph;
    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        graph = wpManager.GetComponent<WaypointManager>().graph;
        currentNode = wps[0];
    }

    // Update is called once per frame

    void LateUpdate()
    {
        if (graph.getPathLength() == 0 || currentWaypointIndex == graph.getPathLength())
        {
            return;
        }
        currentNode = graph.getPathPoint(currentWaypointIndex);
        if (Vector3.Distance(graph.getPathPoint(currentWaypointIndex).transform.position, transform.position) < accuracy)
        {
            currentWaypointIndex++;
        }
        if (currentWaypointIndex < graph.getPathLength())
        {
            goal = graph.getPathPoint(currentWaypointIndex).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
    public void GoTo1()
    {
        graph.AStar(currentNode, wps[0]);
        currentWaypointIndex = 0;
    }
    public void GoTo2()
    {
        graph.AStar(currentNode, wps[1]);
        currentWaypointIndex = 0;
    }
    public void GoTo3()
    {
        graph.AStar(currentNode, wps[2]);
        currentWaypointIndex = 0;
    }
    public void GoTo4()
    {
        graph.AStar(currentNode, wps[3]);
        currentWaypointIndex = 0;
    }
    public void GoTo5()
    {
        graph.AStar(currentNode, wps[4]);
        currentWaypointIndex = 0;
    }
    public void GoTo6()
    {
        graph.AStar(currentNode, wps[5]);
        currentWaypointIndex = 0;
    }
    public void GoTo7()
    {
        graph.AStar(currentNode, wps[6]);
        currentWaypointIndex = 0;
    }
    public void GoTo8()
    {
        graph.AStar(currentNode, wps[7]);
        currentWaypointIndex = 0;
    }
    public void GoTo9()
    {
        graph.AStar(currentNode, wps[8]);
        currentWaypointIndex = 0;
    }
    public void GoTo10()
    {
        graph.AStar(currentNode, wps[9]);
        currentWaypointIndex = 0;
    }
    public void GoTo11()
    {
        graph.AStar(currentNode, wps[10]);
        currentWaypointIndex = 0;
    }
    public void GoTo12()
    {
        graph.AStar(currentNode, wps[11]);
        currentWaypointIndex = 0;
    }
}
