using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{

    public float bulletDuration;
    public float damage;

   

    private void Update()
    {
        bulletDuration -= Time.deltaTime;


        if(bulletDuration <= 0)
        {
            Destroy(gameObject);
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "floor" )
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            
            collision.gameObject.GetComponent<DestroyEnemy>().HP -= damage;
            Destroy(gameObject);

        }

    }

}
