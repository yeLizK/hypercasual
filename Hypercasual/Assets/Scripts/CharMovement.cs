using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Vector3 destination;
    private Animator CharAnim;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        CharAnim = GetComponent<Animator>();
        StartCoroutine(AssignRandomDestination());
    }

    private void Update()
    {
        if(GameManager.Instance.isGameOn)
        {
            if (Vector3.Distance(transform.position, destination) < 0.7f)
            {
                StartCoroutine(AssignRandomDestination());
            }
            navMeshAgent.destination = destination;

        }
    }

    private IEnumerator AssignRandomDestination()
    {
        yield return new WaitForSeconds(4f);
        float tempXPos = Random.Range(-3.6f, 3.6f);
        float tempZPos = Random.Range(13f, 26f);
        destination = new Vector3(tempXPos, -7f, tempZPos);    }
}
