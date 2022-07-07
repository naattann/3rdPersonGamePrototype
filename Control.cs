using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Control : MonoBehaviour


{
    // Start is called before the first frame update


    private Rigidbody rb;
    public float speed ;
    public float speedAir;

    public bool isGrounded;
    public Transform Camera;
    public int maxJumps;
    public int countJumps = 0;
    public bool canJump;
    public float JumpUpwardForce;
    public float JumpAheadForce;
    public float staffDamage;
    public bool isBurning = false;
    public bool isFireResistant;

   


    //melee attack

    public Transform meleeAttackPoint;
    public float attackRange = 5;
    public LayerMask enemyMask;
    public LayerMask groundMask;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 2f, groundMask);


        if(isGrounded == true)
        {
            
            countJumps = 0;
            canJump = true;
        }

 


            if (Input.GetKeyDown(KeyCode.Mouse1)==true)
            Attack();


        Vector3 move = new Vector3(Input.GetAxis("Horizontal") , 0f , Input.GetAxis("Vertical")).normalized;

        //float inputY = Input.GetAxis("Vertical");
       // float inputX = Input.GetAxis("Horizontal");


        if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            if (isGrounded == true)
            {
                transform.Translate(move.normalized * speed * Time.deltaTime, Space.Self);

                // rb.velocity = transform.forward * inputY * speed + transform.right * inputX * speed;
                //rb.AddRelativeForce(Time.deltaTime * inputX * speed, 0, Time.deltaTime * inputY * speed, ForceMode.VelocityChange);
               // rb.velocity = new Vector3(0, rb.velocity.y, 0);


            }

            if (isGrounded == false)
            {
                 transform.Translate(move.normalized * speedAir * Time.deltaTime, Space.Self);
                // rb.velocity = transform.forward * inputY * speed/2 + transform.right * inputX * speed/2;
                //rb.AddRelativeForce(Time.deltaTime * inputX * speed, 0, Time.deltaTime * inputY * speed, ForceMode.VelocityChange);
                //rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }

            if (Input.GetKeyDown("space") && canJump == true)
            {

               // rb.AddForce(Vector3.up * Mathf.Sqrt(JumpUpwardForce* -2f * Physics.gravity.y), ForceMode.VelocityChange);
            

            rb.AddForce(transform.up * JumpUpwardForce);
            rb.AddRelativeForce(move.normalized * JumpAheadForce);
            countJumps++;
                if (countJumps >= maxJumps)
                    canJump = false;
            }

        }


        transform.rotation = Quaternion.LookRotation(Camera.transform.forward, Camera.transform.up) ;   // Camera.transform.up
        
    }


    private void OnCollisionEnter(Collision collision)
    {
      //  if(collision.gameObject.tag == "floor")
      //  {
        //    isGrounded = true;
         //   countJumps = 0;
         //   canJump = true;

       // }
    }

    private void OnCollisionExit(Collision collision)
    {
       // if (collision.gameObject.tag == "floor" )
       // {
        //    isGrounded = false;
            
        //}
    }


    public void Attack()
    {
        
        Collider[] hitEnemies = Physics.OverlapSphere(meleeAttackPoint.position, attackRange ,enemyMask);


        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<DestroyEnemy>().HP -= staffDamage;

        }

    }
}
