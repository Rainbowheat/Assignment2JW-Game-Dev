using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed;
    public float sprint;
    public float jumpForce;
    public int jump;


    public float onGround;
    public float horizontalMovement;
    public float verticalMovement;
    public Rigidbody myBody;
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) { speed = speed + sprint; }
        if (Input.GetKeyUp(KeyCode.LeftShift)) { speed = speed - sprint; }

        if(Input.GetKeyDown(KeyCode.Space) && onGround != 0)
        {
            myBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = onGround - 1;
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        verticalMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(horizontalMovement, 0, verticalMovement);

        

        

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("WHA");
        if (other.tag == "Floor")
        {
            onGround = jump;
        }
    }
}
