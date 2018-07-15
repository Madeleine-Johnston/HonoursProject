using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpiderMovement : MonoBehaviour {


    public float speed;

    public Rigidbody rb;

    public float rand_h;
    public float rand_v;
    public float accelarate = 5;

    public GameObject PC_Spider__;
    public GameObject PC_Spider__2;
    public GameObject PC_Spider__3;

    float KeyDownTime = float.MinValue;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rand_h = Random.Range(0, 2);
        rand_v = Random.Range(0, 2);

    }

    void OnCollisionEnter(Collision col)
    {
       
        rand_h = (rand_h * (-1) + 0.3f);  //invert the direction its facing and add 0.3 so that it doesnt stay parallel and moves to different places
        rand_v = (rand_v * (-1) + 0.3f); //0.3f

        rb.freezeRotation = true;     //stopped continous rotation after collition
    }



    void movement()
    {
        transform.position = gameObject.transform.position;
        transform.LookAt(transform.position + rb.velocity);     //face direction of movement

        float moveHorizontal = rand_h;// + 0.1f;
        float moveVertical = rand_v;// + 0.1f;

        Vector3 Movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(Movement * speed);

        if (Input.GetKeyDown(KeyCode.R))
        {
            PC_Spider__.transform.position = new Vector3(-25.5f, 0f, -6.35f);        //respawn spiders incase stuck ect.
            PC_Spider__2.transform.position = new Vector3(11.1f, 0f, 7.16f);
            PC_Spider__3.transform.position = new Vector3(-4.5f, 0f, -38.8f);

        }



    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.velocity = new Vector3(1, 0, 1);
            movement();
        }
        else
        { 
       
            movement();
        }
    }



    void OnMouseDown()
    {

        StartCoroutine(Burst(1.0f));

        //run away/new direction

        //rb.AddForce(movement * speed);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    KeyDownTime = Time.time;

        // if (Time.time < KeyDownTime + 0.1f)
        // {
        //rb.velocity = new Vector3(0, 0, 0) * accelarate;
        //speed = 10;
        //    Debug.Log("Added Speed.");
        //    yield WaitForSeconds(0.25);
        //    speed = 1;

        //}

        //}

    }

    IEnumerator Burst(float seconds)
    {
        speed = 15;
        Debug.Log("Added Speed.");
        yield return new WaitForSeconds(seconds);
        speed = 1;
    }

}
