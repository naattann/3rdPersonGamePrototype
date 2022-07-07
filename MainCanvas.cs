using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public GameObject mapCanvas;
    public GameObject heroesCanvas;
    public GameObject optionsCanvas;
    // Start is called before the first frame update



    // Start is called before the first frame update
    void Start()
    {


        mapCanvas.SetActive(false);
        heroesCanvas.SetActive(false);
        optionsCanvas.SetActive(false);


    }


}
