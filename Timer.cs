using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{


    public float roundTime = 0.0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        roundTime += Time.deltaTime;


    }
}
