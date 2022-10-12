using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPerson : MonoBehaviour
{
    NavMeshAgent follower;
    public Transform player;
    Collider myCol;
    // Start is called before the first frame update
    void Start()
    {
        follower = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        follower.SetDestination(player.position);
        OnTriggerEnter(myCol);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
