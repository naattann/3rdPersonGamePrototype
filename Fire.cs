using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public float duration;
    public float damage;
    public float attackRate;


    private float time2;
    private float time;
    public GameObject Player;
    public GameObject Enemy;


    private bool isItPlayer;
    private bool isFireResistant;
    public bool isAttached;



    // Start is called before the first frame update
    void Start()
    {

        isAttached = false;
        time = duration;
        time2 = time;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        



        if (time > 0)
        {
            time -= Time.deltaTime;

            if (isAttached == true)
            {


             

                    if (time > 0 && isItPlayer == true)
                    {
                       

                        if (time2 - attackRate >= time && Player != null)
                        {
                            Debug.Log(Player);
                            Player.GetComponent<Health>().healthValue -= damage / 100;
                            time2 = time;

                        }


                    }

                    if (time > 0 && isItPlayer == false)
                    {
                        if (Enemy = null)
                        {
                            Destroy(gameObject);
                            

                        }

                        if (time2 - attackRate >= time && Enemy != null)
                        {
                            Debug.Log(Enemy);
                            Enemy.GetComponent<DestroyEnemy>().HP -= damage;
                            time2 = time;

                        }


                    }

                





                if (time <= 0 && isItPlayer == true)
                {
                    if (Player = null)
                    {
                        Destroy(gameObject);


                    }

                    if(Player != null)
                    {
                        Player.GetComponent<Control>().isBurning = false;

                        Destroy(gameObject);
                    }
                    

                }

                if (time <= 0 && isItPlayer == false)
                {
                    if (Enemy = null)
                    {
                        Destroy(gameObject);


                    }

                    if(Enemy != null)
                    {
                        Enemy.GetComponent<EnemyAI>().isBurning = false;

                        Destroy(gameObject);
                    }


                }
            }

            if (isAttached == false)
            {

                if (time <= 0)
                {


                    Destroy(gameObject);
                    

                }

            }

        }

    }


    private void OnTriggerEnter(Collider other)
    {





        if (other.tag == "Enemy")                              

        {

            if (other.GetComponent<EnemyAI>().isBurning == false)
            {

                var newFire = Instantiate(gameObject, other.transform);

                newFire.transform.position = other.transform.position;
                Enemy = other.gameObject;

                other.GetComponent<EnemyAI>().isBurning = true;
                isFireResistant = Enemy.GetComponent<EnemyAI>().isFireResistant;

                isItPlayer = false;
                isAttached = true;
                


            }

        }






        if (other.tag == "Player")                             

        {

            if (other.GetComponent<Control>().isBurning == false)
            {

                var newFire = Instantiate(gameObject, other.transform);

                newFire.transform.position = other.transform.position;
                Player = other.gameObject;

                other.GetComponent<Control>().isBurning = true;
                isFireResistant = Player.GetComponent<Control>().isFireResistant;

                isItPlayer = true;
                isAttached = true;



            }

        }




    }




}
