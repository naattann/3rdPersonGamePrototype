using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{

    public GameObject Player;


    public float exp;
    public  float HP;

    private void Update()
    {
        if(HP<=0)
        {
            Die();

        }
    }



    private void Die()
    {
        Player = GameObject.Find("Player");

        Player.GetComponent<SaveScript>().exp += exp;

        Destroy(this.gameObject);

    }

    // Start is called before the first frame update
   
}
