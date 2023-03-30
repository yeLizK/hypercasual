using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Vector3 destination;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(AssignRandomDestination());
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position,destination)<0.5f)
        {
            StartCoroutine(AssignRandomDestination());
        }
            navMeshAgent.destination = destination;
    }

    private IEnumerator AssignRandomDestination()
    {
        yield return new WaitForSeconds(4f);
        float tempXPos = Random.Range(-3.6f, 3.6f);
        float tempZPos = Random.Range(13f, 26f);
        destination = new Vector3(tempXPos, -7f, tempZPos);    }
}
