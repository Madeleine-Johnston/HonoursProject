//using UnityEngine;
//using System.Collections;

//public class PlayerController : MonoBehaviour
//{

//    public float speed;
//    private vec2 mousePos;

//    private Rigidbody rb;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//    }

//    void FixedUpdate()
//    {

//        mousePos = Input.mousePosition;
//        float moveHorizontal = mousePos;
//        float moveVertical = Input.GetAxis("Vertical");

//        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

//        rb.AddForce(movement * speed);

//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    private float xForce;
    private float zForce;
    private Vector3 force;

    private float pitch = 0.0F;
    private float yaw = 0.0F;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        xForce = Input.GetAxis("Horizontal");
        zForce = Input.GetAxis("Vertical");

        pitch -= Input.GetAxis("Mouse Y");
        yaw += Input.GetAxis("Mouse X");

        if (Input.GetKeyUp(KeyCode.W))
        {
            rb.Sleep();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.Sleep();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.Sleep();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.Sleep();
        }

    }

    void LateUpdate()
    {

        force = new Vector3((xForce*2), 0.0F, (zForce*2));

        // rotate object to face mouse direction
        rb.transform.localEulerAngles = new Vector3(0.0f, yaw, 0.0F);

        // move object in facing direction relative to local (AddRelative) not world (AddForce) coordinates
        rb.AddRelativeForce(force);
                
    }

}
