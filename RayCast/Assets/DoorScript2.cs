using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript2 : MonoBehaviour
{
    public GameObject doorEntry;
    public GameObject doorExit;

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        doorEntry.SetActive(false);
        doorExit.SetActive(true);
    }
}
