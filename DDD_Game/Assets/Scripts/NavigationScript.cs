using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;



public class NavigationScript : MonoBehaviour
{
    private enum State
    {
        Roam, // Wide area wander
        Search, // Small area wander
        Chase // Target player

    }

    public GameObject player;
    private Vector3 target;
    private NavMeshAgent agent;
    private State state;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = State.Roam;
        target = agent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 1f);
        if(hit.collider != null && hit.collider.CompareTag("Door"))
        {
            hit.collider.GetComponent<Doors>().MonsterDoor();
        }

        agent.destination = target;
        switch (state)
        {
            case (State.Chase):
                if (!CanSee()) { state = State.Search; break; }
                target = player.transform.position;
                break;
            case (State.Search):
                if(CanSee()) { state = State.Chase; break; }
                Coroutine coroutine = StartCoroutine(search());

            break;
            case (State.Roam):
                if(CanSee()) { state = State.Chase; break; }
                SelectRandomDestination(60);
                break;
        }
  
    }

    private IEnumerator search()
    {
        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
            SelectRandomDestination(10);
        }
        state = State.Roam;
    }
    private bool CanSee()
    {
        Vector3 directionToTarget = player.transform.position - transform.position;

        RaycastHit hit;
        Physics.Raycast(transform.position, directionToTarget, out hit);
        if (hit.collider.gameObject.name == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    

    private void SelectRandomDestination(int radius)
    {
        if (agent.transform.position.x + 2 > target.x && agent.transform.position.x - 2 < target.x && agent.transform.position.z + 2 > target.z && agent.transform.position.z - 2 < target.z)
        {
            while (true)
            {
                Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;

                // Ensure the random position is within the NavMesh
                randomDirection += player.transform.position;

                // Sample a valid point on the NavMesh
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
                {
                    // Move the NavMeshAgent to the valid position on the NavMesh
                    target = hit.position;
                    break;
                }
            }
        }
        
    }
}
