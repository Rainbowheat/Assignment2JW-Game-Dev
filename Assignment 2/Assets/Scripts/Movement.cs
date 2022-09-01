using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float sprint;
    public bool onGround;
    public Rigidbody myBody;
    public Collider myCollider;
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(horizontalInput, 0, verticalInput);

        if (Input.GetKeyDown(KeyCode.LeftShift)) { speed = speed + sprint; }
        if (Input.GetKeyUp(KeyCode.LeftShift)) { speed = speed - sprint; }
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            myBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("WHA");
        if (other.tag == "Floor")
        {
            onGround = true;
        }
    }
}
