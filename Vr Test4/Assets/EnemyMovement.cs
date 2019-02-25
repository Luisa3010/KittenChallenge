using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public GameObject Player;
    NavMeshAgent agent;
    
    void start()
    {
        agent = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void LateUpdate()
    {

        GetComponent<NavMeshAgent>().destination = Player.transform.position;
       
    }
}
