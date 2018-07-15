using UnityEngine;
using System.Collections;

public class SpiderMoveFantasy : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    private float rand_h;
    private float rand_v;
    //private int check = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rand_h = Random.Range(0, 2);
        rand_v = Random.Range(0, 2);

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Wall_Left" || col.gameObject.name == "Wall_Back" || col.gameObject.name == "Wall_Right" || col.gameObject.name == "Wall_Front")
        {
            rand_h = 0.2F;
            rand_v = 0.9F;
            speed = -speed;         //start facing other direction when collides with wall
                                    //rand_h = rand_h * (-1) + 0.3f;  //invert the direction its facing and add 0.3 so that it doesnt stay parallel and moves to different places
                                    //rand_v = rand_v * (-1) + 0.3f;

            }




           // rb.freezeRotation = true;     //stopped continous rotation after collition
    }


    void FixedUpdate()
    {

        //transform.position = gameObject.transform.position;
        //transform.LookAt(transform.position + rb.velocity);

        float moveHorizontal = rand_h + 0.1f;
        float moveVertical = rand_v + 0.1f;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);


    }


}