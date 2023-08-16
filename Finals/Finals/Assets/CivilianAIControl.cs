using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CivilianAIControl : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    Animator animator;
    public GameObject target;
    float speedMultiplier;
    float detectionRadius = 5;
    float fleeRadius = 10;
    // Start is called before the first frame update

    void ResetAgent()
    {
        speedMultiplier = Random.Range(0.1f, 1.5f);
        agent.speed = 2 * speedMultiplier;
        agent.angularSpeed = 120;
        animator.SetFloat("speedMultiplier", speedMultiplier);
        animator.SetTrigger("isWalking");
        agent.ResetPath();
    }
    void Start()
    {
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        animator = this.GetComponent<Animator>();
        animator.SetFloat("wOffset", Random.Range(0, 1));
        ResetAgent();
    }

    void fleeDestroy()
    {
        Vector3 fleeDirection = target.transform.position - this.transform.position;
        animator.SetTrigger("isRunning");
        agent.speed = 10;
        agent.angularSpeed = 500;
        agent.SetDestination(this.transform.position - fleeDirection);
        
    }

    // Update is called once per frame
    public void DetectNewObstacle(Vector3 location)
    {
        if (Vector3.Distance(location, this.transform.position) < detectionRadius)
        {
            Vector3 fleeDirection = (this.transform.position - location).normalized;
            Vector3 newGoal = this.transform.position + fleeDirection * fleeRadius;

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(newGoal, path);

            if (path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);
                animator.SetTrigger("isRunning");
                agent.speed = 10;
                agent.angularSpeed = 500;
            }
        }
    }
    public void DetectNewLure(Vector3 location)
    {
        if (Vector3.Distance(location, this.transform.position) < detectionRadius)
        {
            Vector3 lureDirection = (this.transform.position - location).normalized;
            Vector3 newGoal = location;

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(newGoal, path);

            if (path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);
                animator.SetTrigger("isRunning");
                agent.speed = 10;
                agent.angularSpeed = 500;
            }
        }
    }
    void LateUpdate()
    {
        float civilianDistance = Vector3.Distance(transform.position, target.transform.position);
        if (civilianDistance < detectionRadius)
        {
            fleeDestroy();
          //  GetComponent<GameManager>().allCivilians--;
            Destroy(gameObject,3);
        }
    }
}
