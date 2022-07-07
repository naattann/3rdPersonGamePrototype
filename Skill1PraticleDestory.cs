using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1PraticleDestory : MonoBehaviour
{

    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         t += Time.deltaTime;

        if (t>1)
        {
            Destroy(gameObject);

        }
    }
}
