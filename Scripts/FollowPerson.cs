using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class FollowPerson : MonoBehaviour
{
    NavMeshAgent follower;
    Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        follower = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") == null)
        {
            player = GameObject.Find("Plane").transform; 
        }
        
        follower.SetDestination(player.position);
        
    }
    
}
