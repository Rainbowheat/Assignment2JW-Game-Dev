using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health = 50;
    public float speed = 10;

    float distanceToo;
    public float distance = 5;
    float distanceMoved;
    bool finished;

    private void Start()
    {
        distanceToo = distance * distance;

    }
    private void Update()
    {
        if (distanceMoved <= 0) { finished = false;}
        if (distanceMoved >= distanceToo) { finished = true;}
        if (finished == false)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            distanceMoved += distance * Time.deltaTime;
        }
        if (finished == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            distanceMoved -= distance * Time.deltaTime;
        }
    }
    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
        else if (health >= 35)
        {
            transform.GetComponentInChildren<MeshRenderer>().material.color = Color.black;
        }
        else if (health <40 && health >= 20 )
        {
            transform.GetComponentInChildren<MeshRenderer>().material.color = Color.magenta;
        }
        else
        {
            transform.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        }
    }

    void Die ()
    {
        Destroy(gameObject);
    } 
}
