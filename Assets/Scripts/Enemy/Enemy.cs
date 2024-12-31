using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public FieldOfView fov;

    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float wait = 1f;
    [SerializeField] private float timeIdle;
    [SerializeField] private GameObject enemyAttack;
    [SerializeField] private Transform[] waypoint;

    private float idle;
    private int targetIndex;

    private NavMeshAgent agent;
    private AIState state;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;

        state = AIState.Idle;

        targetIndex = 0;

        idle = timeIdle;

    }

    private void Update()
    {
        EnemyAttack();

        switch (state)
        {
            case AIState.Idle:
                Idle();
                break;
            case AIState.Patrol:
                Patrol();
                break;
            case AIState.Chase:
                Chase();
                break;
        }
    }

    private void Idle()
    {
        idle -= Time.deltaTime;
        Debug.Log("idle");

        if(idle <= 0)
        {
            targetIndex = (targetIndex + 1) % waypoint.Length;
            state = AIState.Patrol;
        }
        
        //FOV Code Should Here
        if (fov.CanSeePlayer)
        {
            state = AIState.Chase;
        }

    }

    private void Patrol()
    {
        Debug.Log("Patrol");

        agent.SetDestination(waypoint[targetIndex].position);

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            idle = timeIdle;
            state = AIState.Idle;
        }

        //FOV Code Should Here
        if (fov.CanSeePlayer)
        {
            state = AIState.Chase;
        }
    }

    private void Chase()
    {
        Debug.Log("Chase");

        agent.SetDestination(target.position);
    }

    private void EnemyAttack()
    {
        wait -= Time.deltaTime;

        if (wait <= 0)
        {
            enemyAttack.SetActive(true);
            if (wait <= -1)
            {
                wait = 1;
            }
        }
        else
        {
            enemyAttack.SetActive(false);
        }
    }

    private enum AIState
    {
        Idle,
        Patrol,
        Chase
    }
}
