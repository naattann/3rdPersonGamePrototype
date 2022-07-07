
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
   
    public Image healthBar;
    public float healthStart;
    public float healthRegeneration;
    public float healthValue;
    
    // Start is called before the first frame update

    void Start()
    {
        healthValue = healthStart/100;
    }

 

    private void Update()
    {

       if(healthValue<=1f)

       healthValue += healthRegeneration/100 * Time.deltaTime;

       healthBar.fillAmount = healthValue;

        if (healthValue <= 0)
            Debug.Log("Player Died");
    }


}
