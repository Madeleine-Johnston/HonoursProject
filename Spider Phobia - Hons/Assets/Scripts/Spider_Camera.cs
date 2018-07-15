//REF: https://www.youtube.com/watch?v=1uTkWPq5_dw

using UnityEngine;
using System.Collections;

public class Spider_Camera : MonoBehaviour
{


    public GameObject spider_myOldOne;

    private Rigidbody rb;

    private Vector3 offset_Spider;

    float arrowMouseSpeed = 0.5f; //was 0.5

    void Start()
    {
        offset_Spider = transform.position - spider_myOldOne.transform.position;
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void LateUpdate()
    {

        transform.position = spider_myOldOne.transform.position + offset_Spider;


        moveCamera(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), arrowMouseSpeed);
    }

    float mouseX;
    float mouseY;
    Quaternion localRotation;
    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    void moveCamera(float horizontal, float verticle, float moveSpeed)
    {
       
        mouseX = horizontal;
        mouseY = -verticle;

        rotY += mouseX * moveSpeed;
        rotX += mouseY * moveSpeed;

        localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }
}