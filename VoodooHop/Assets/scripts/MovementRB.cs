using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRB : MonoBehaviour
{
    Rigidbody rb;
    public float speed =10f; 
    public float turnSpeed = 80f; // set values in Unity inspector
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
   
   
    void FixedUpdate()
    {
      
        //movement using key input
        bool w = Input.GetKey(KeyCode.W);
        bool a = Input.GetKey(KeyCode.A);
        bool s = Input.GetKey(KeyCode.S);
        bool d = Input.GetKey(KeyCode.D);
        bool q = Input.GetKey(KeyCode.Q);
        bool e = Input.GetKey(KeyCode.E);



        if (w)
        {
            Vector3 moveForward = rb.transform.forward; // rb.transform.forward to get local forward of player
            moveForward = moveForward.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + moveForward);
        }
        if (s)
        {
            Vector3 moveBack = -rb.transform.forward;
            moveBack = moveBack.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + moveBack);
        }
        if (a)
        {
            Vector3 moveLeft = -rb.transform.right;
            moveLeft = moveLeft.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + moveLeft);
        }
        if (d)
        {
            Vector3 moveRight = rb.transform.right;
            moveRight = moveRight.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + moveRight);
        }

        //Rotation control
        if (q)
        {
            Vector3 turnVelocity = new Vector3(0, turnSpeed, 0);
            Quaternion turnLeft = Quaternion.Euler(-turnVelocity* Time.deltaTime);

            //turnLeft = turnLeft.normalized * speed * Time.deltaTime;
            rb.MoveRotation(rb.rotation * turnLeft);
        }
        if (e)
        {
            Vector3 turnVelocity = new Vector3(0, turnSpeed, 0);
            Quaternion turnLeft = Quaternion.Euler(turnVelocity * Time.deltaTime);

            //turnLeft = turnLeft.normalized * speed * Time.deltaTime;
            rb.MoveRotation(rb.rotation * turnLeft);
        }
        
    }
}
