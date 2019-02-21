using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public GameObject Player;
    public float speed = 0.01f;
    NavMeshAgent agent;
    
    void start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 PlayerPos = new Vector3(Player.transform.position.x,0.5f, Player.transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, PlayerPos, Time.deltaTime);
        //transform.LookAt(PlayerPos);
        
        GetComponent<NavMeshAgent>().destination = Player.transform.position;
    }
}
