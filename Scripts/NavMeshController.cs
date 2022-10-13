using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;


public class NavMeshController : MonoBehaviour
{
    public Camera cam;
    NavMeshAgent agent;
    public GameObject DeathMenu;
    public TextMeshProUGUI lives;
    int totalLives = 3;
    BoxCollider myCol;
    int money;
    float respawnTime;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        myCol = GetComponent<BoxCollider>();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        OnTriggerEnter(myCol);
        lives.text = totalLives.ToString("Lives: 0");
        respawnTime += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && respawnTime > 3)
        {
            totalLives -= 1;
            transform.position = new Vector3(0, 5, 0);
            agent.SetDestination(transform.position);
        }
        if (other.CompareTag("Enemy") && totalLives == 0)
        {
            Destroy(this.gameObject);
            DeathMenu.SetActive(true);
        }
    }
    public void respawn()
    {
        totalLives += 3;
        if (money == 5)
        {
            totalLives += 2;
        } 
    }
}
