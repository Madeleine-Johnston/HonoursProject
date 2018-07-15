using UnityEngine;
using System.Collections;

public class spiderMovement : MonoBehaviour
{

    public float speed;

    public Rigidbody rb;

    public float rand_h;
    public float rand_v;
    public Animation anim;
    public Animation anim2;

    public GameObject spider_1;
    public GameObject spider_2;
    public GameObject spider_3;
    //public GameObject spider_myOldOne_4;
    public bool spiderDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rand_h = Random.Range(0, 2);
        rand_v = Random.Range(0, 2);

    }

    void OnCollisionEnter(Collision col)
    {
        // if (col.gameObject.name == "Wall_Left" || col.gameObject.name == "Wall_Back" || col.gameObject.name == "Wall_Right" || col.gameObject.name == "Wall_Front" || col.gameObject.name == "Cube" || col.gameObject.name == "Cube (1)" || col.gameObject.name == "Cube (2)" || col.gameObject.name == "Cube (3)")
        //{
        //rand_h = 0.2F;
        //rand_v = 0.9F;
        //speed = -speed;         //start facing other direction when collides with wall
        rand_h = (rand_h * (-1) + 0.3f);  //invert the direction its facing and add 0.3 so that it doesnt stay parallel and moves to different places
        rand_v = (rand_v * (-1) + 0.3f); //0.3f

        //}




        rb.freezeRotation = true;     //stopped continous rotation after collition
    }



    void movement()
    {
        transform.position = gameObject.transform.position;
        transform.LookAt(transform.position + rb.velocity);     //face direction of movement

        float moveHorizontal = rand_h;// + 0.1f;
        float moveVertical = rand_v;// + 0.1f;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.R))
        {
            spider_1.transform.position = new Vector3(-25.5f, 0f, -6.35f);        //respawn spiders incase stuck ect.
            spider_2.transform.position = new Vector3(11.1f, 0f, 7.16f);
            spider_3.transform.position = new Vector3(-4.5f, 0f, -38.8f);
          
        }



        //if (Input.GetMouseButtonDown(0))        //left click
        //{

        //    spiderDead = true;
        //    rb.velocity = new Vector3(0, 0, 0);
        //    anim = GetComponent<Animation>();
        //    anim.Play("death2");    //flat death
        //    Debug.Log("Pressed left click.");

        //}
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            spiderDead = false;
            anim = GetComponent<Animation>();
            anim.Play("walk");
            rb.velocity = new Vector3(1, 0, 1);
            movement();
        }

        if (spiderDead == false)
        {
            movement();
        }
    }

    //void respawn()
    //{
    //    //spider_myOldOne.transform.position = new Vector3(-3, 0, -6);        //respawn spiders incase stuck ect.
    //    //spider_myOldOne_2.transform.position = new Vector3(4, 0, 7);
    //    spiderDead = false;
    //    anim = GetComponent<Animation>();
    //    anim.Play("walk");
    //    rb.velocity = new Vector3(1, 0, 1);
    //    movement();
    //}

    void OnMouseDown()
    {
        /////moved to new class

        if (spiderDead == false)        //first click
        {
            spiderDead = true;
            rb.velocity = new Vector3(0, 0, 0);
            anim = GetComponent<Animation>();
            anim.Play("death2");    //flat death
            Debug.Log("Pressed left click.");

        }

        else                                    //second click
        {
                speed = 0;            
                spiderDead = true;
                rb.velocity = new Vector3(0, 0, 0);
                anim = GetComponent<Animation>();
                anim.Play("death1");    //currled death
                Debug.Log("Pressed right click.");
            
            //if (Input.GetKeyDown(KeyCode.R))
            //{
            //    respawn();
            //    //        //spider_myOldOne.transform.position = new Vector3(-3, 0, -6);        //respawn spiders incase stuck ect.
            //    //        //spider_myOldOne_2.transform.position = new Vector3(4, 0, 7);

            //    //        // spider_myOldOne_3.transform.position = new Vector3(-6, 0, 7);
            //    //        // spider_myOldOne_4.transform.position = new Vector3(5, 0, -4);
            //    //    }

            //}

            //if (spiderDead == false)
            //{
            //    movement();
            //}

            //else
            //{
            //    transform.position = gameObject.transform.position;
            //    transform.LookAt(transform.position + rb.velocity);     //face direction of movement

            //    float moveHorizontal = rand_h;// + 0.1f;
            //    float moveVertical = rand_v;// + 0.1f;

            //    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            //    rb.AddForce(movement * speed);

            //    if (Input.GetKeyDown(KeyCode.R))
            //    {
            //        spider_myOldOne.transform.position = new Vector3(-3, 0, -6);        //respawn spiders incase stuck ect.
            //        spider_myOldOne_2.transform.position = new Vector3(4, 0, 7);
            //        // spider_myOldOne_3.transform.position = new Vector3(-6, 0, 7);
            //        // spider_myOldOne_4.transform.position = new Vector3(5, 0, -4);
            //    }


            //    if (Input.GetMouseButtonDown(0))        //left click
            //    {
            //        spiderDead = true;
            //        rb.velocity = new Vector3(0, 0, 0);
            //        anim = GetComponent<Animation>();
            //        anim.Play("death2");    //flat death
            //        Debug.Log("Pressed left click.");

            //    }


        }
    }

}

    

