using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Camera fpsCam;

    public float damage = 10f;
    public float headDamage = 50f;
    public float range = 100f;
    public float shootScore;
    public float highScore;
    public float timeSoFar;
    public GameObject entryDoor;
    public GameObject exitDoor;
    public bool inlevel;

    public ParticleSystem bangbang;
    public TextMeshProUGUI txtS;
    public TextMeshProUGUI txt2HS;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        txtS.text = shootScore.ToString("Score: 0");
        txt2HS.text = highScore.ToString("HighScore: 0");
        
        if (entryDoor.activeSelf == false)
        {
            timeSoFar += 1 * Time.deltaTime;
        }
        if (entryDoor.activeSelf == true)
        {
            if (highScore < shootScore/timeSoFar)
            {
                highScore = shootScore / timeSoFar;
            }
            shootScore = 0;
        }

    }

    void Shoot ()
    {
        bangbang.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.parent.transform.name);
            Debug.Log(hit.transform.parent.transform.GetComponent<EnemyScript>());

            EnemyScript parent = hit.transform.parent.transform.GetComponent<EnemyScript>();
            Transform target = hit.transform;

            if (parent != null)
            {
                if (target.tag == "Head")
                {                   
                    parent.TakeDamage(headDamage);
                    shootScore += 100;
                }
                
                if (target.tag == "Body")
                {
                    parent.TakeDamage(damage);
                    shootScore += 10;
                }

                else {
                    parent.TakeDamage(damage);
                }
                Debug.Log(target.transform.name);
                Debug.Log(target.transform.tag);
            }
        }
    }
}
