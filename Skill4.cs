using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Skill4 : MonoBehaviour
{



    public bool ultimateActive;
    public float speedModifier;
    public float jumpModifier;
    public float manaModifier;

    public float ultimateTime;
    private float timeLeft;


    public float SkillCooldown;
    public float Cooldown;
    public float minimalTradeMana;
    public float ManaCost;
    public bool skillReady;
    public float conversion;


    public Image Mana;
    public Image Health;
    public TextMeshProUGUI cooldownText;

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha4) && skillReady == true)

        {

            Ultimate();
            CooldownMana();
            timeLeft = ultimateTime;
            ultimateActive = true;
            skillReady = false;


        }






        if(ultimateActive == true)
        {
            timeLeft -= Time.deltaTime;




            if(timeLeft < 0)
            {

                gameObject.GetComponent<Control>().speed /= speedModifier;
                gameObject.GetComponent<Control>().JumpUpwardForce /= jumpModifier;
                gameObject.GetComponent<Control>().JumpAheadForce /= jumpModifier;
                gameObject.GetComponent<Mana>().manaRegeneration /= manaModifier;

                

                ultimateActive = false;

            }
            

        }


        CooldownDisplay();
       


    }


    public void Ultimate()
    {

       

        conversion = gameObject.GetComponent<Health>().healthValue;
        gameObject.GetComponent<Health>().healthValue = gameObject.GetComponent<Mana>().manaValue;
        gameObject.GetComponent<Mana>().manaValue = conversion;


        gameObject.GetComponent<Control>().speed *= speedModifier;
        gameObject.GetComponent<Control>().JumpUpwardForce *= jumpModifier;
        gameObject.GetComponent<Control>().JumpAheadForce *= jumpModifier;
        gameObject.GetComponent<Mana>().manaRegeneration *= manaModifier;

    }


    void CooldownMana()
    {

        SkillCooldown = Cooldown;

        skillReady = false;

        float ManaMinus;

        ManaMinus = conversion - ManaCost / 100f;

        Mana.fillAmount = ManaMinus;


    }


    void CooldownDisplay()
    {
        //Cooldown display                     // A little different approach than for other skills to fit funcionality

        if (SkillCooldown > -0.01f)
        {
            SkillCooldown -= Time.deltaTime;

            cooldownText.text = string.Format("{0:0}", SkillCooldown);
           

        }

        float currentMana = Mana.fillAmount;

        if (currentMana >= (ManaCost / 100f) + (minimalTradeMana / 100f) && SkillCooldown < 0.0f)
        {
            cooldownText.color = Color.white;
            skillReady = true;

        }

        if (currentMana < (ManaCost / 100f) + (minimalTradeMana / 100f))
        {
            skillReady = false;
            cooldownText.color = Color.blue;

        }

        if (currentMana > ManaCost / 100f && cooldownText.color == Color.blue)
        {

            cooldownText.color = Color.white;
        }

    }


}
