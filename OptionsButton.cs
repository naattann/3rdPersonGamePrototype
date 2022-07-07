using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{


    public GameObject currentCanvas;
    public GameObject futureCanvas;
    // Start is called before the first frame update
   


    public void ChangeChanvas()
    {
        futureCanvas.SetActive(true);
        currentCanvas.SetActive(false);

    }
}
