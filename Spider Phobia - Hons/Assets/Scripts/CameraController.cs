//REF: https://www.youtube.com/watch?v=1uTkWPq5_dw

using UnityEngine;
using System.Collections;


public class CameraController : spiderMovement
{
    

    public GameObject player;

    public Vector3 offset;

    float arrowMouseSpeed = 1.0f;

    void Start()
    {
        offset = transform.position - player.transform.position;
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        moveCamera(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), arrowMouseSpeed);
    }

    float mouseX;
    float mouseY;
    Quaternion localRotation;
    public float rotY = 0.0f; // rotation around the up/y axis
    public float rotX = 0.0f; // rotation around the right/x axis

    void moveCamera(float horizontal, float verticle, float moveSpeed)
    {
        mouseX = horizontal;
        mouseY = -verticle;

        rotY += mouseX * moveSpeed;
        rotX += mouseY * moveSpeed;

        localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            //FindObjectOfType<CameraController>().Function();
    //        }
    //    }
    //}

}