using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DisableMeshAgent : MonoBehaviour
{

    NavMeshAgent agent;
    EnemyMovement movement;
    bool isInHand = false;
    bool isOnFloor = true;
    bool isInHole = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        movement = GetComponent<EnemyMovement>();
    }

    


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            deactivateMovement();
            isInHand = true;

        }

        if (other.gameObject.CompareTag("Hole"))
        {
            deactivateMovement();
            isInHole = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInHand = false;
            if (isOnFloor)
            {
                activateMovement();
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnFloor = true;
            if (!isInHand)
            {
                activateMovement();
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnFloor = true;
            if (!isInHand)
            {
                activateMovement();
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnFloor = false;
            deactivateMovement();
        }
    }




    void activateMovement()
    {
        if (!isInHole)
        {
            agent.enabled = true;
            movement.enabled = true;
        }
    }

    void deactivateMovement()
    {
        agent.enabled = false;
        movement.enabled = false;
    }




}
