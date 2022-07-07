using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2Bullet : MonoBehaviour
{

    public float bulletDuration;
    private float damage;
    public GameObject Player;



    private void Start()
    {
        Player = GameObject.FindWithTag("Player");

        damage = Player.GetComponent<Skill2>().damage;
    }

    private void Update()
    {
        bulletDuration -= Time.deltaTime;


        if (bulletDuration <= 0)
        {
            Destroy(gameObject);
        }
    }



    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "floor")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {

            collision.gameObject.GetComponent<DestroyEnemy>().HP -= damage;
            Debug.Log(damage);
            Destroy(gameObject);

        }

    }

}
