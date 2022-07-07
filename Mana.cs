using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public Image manaBar;
    
    public float manaStart;
    public float manaRegeneration;
    public float manaValue;
    public bool isGrounded;

    void Start()
    {        
        manaBar.fillAmount = manaStart/100f;
        isGrounded = GetComponent<Control>().isGrounded;
    }

    void Update()
    {
        manaValue = manaBar.fillAmount;
        isGrounded = GetComponent<Control>().isGrounded;

        if (Input.GetKey(KeyCode.LeftShift) && manaValue <= 1f && isGrounded == true)
            manaValue += manaRegeneration/100 * Time.deltaTime;

        manaBar.fillAmount = manaValue;
    }
}
