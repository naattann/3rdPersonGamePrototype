using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skill1 : MonoBehaviour
{



    public TextMeshProUGUI cooldownText;

    public Image Mana;
    [SerializeField] float Cooldown;
    [SerializeField] float ManaCost;


    public GameObject hitExplosion;
    // Start is called before the first frame update

    public LayerMask Enemy;

    private bool skillReady;

    public float range ;
    public float damage;
    public float knockForce;

    private float SkillCooldown;


    void Start()
    {
        skillReady = true;
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(Input.GetKeyDown(KeyCode.Alpha1) && skillReady ==true)
        {
            Cast();
            
            CooldownMana();
           
        }

        CooldownDisplay();

    }


    void Cast()
    {
        Collider[] enemiesHit = Physics.OverlapSphere(transform.position, range, Enemy);

        

        foreach (var enemyHit in enemiesHit)
        {
           enemyHit.GetComponent<DestroyEnemy>().HP -= damage ;

            Vector3 direction = (enemyHit.transform.position - gameObject.transform.position).normalized;

            enemyHit.GetComponent<Rigidbody>().AddForce(direction * knockForce,ForceMode.Impulse);

            Instantiate(hitExplosion, enemyHit.transform);

        }

    }


    void CooldownMana()
    {

        SkillCooldown = Cooldown;

        skillReady = false;

        float ManaMinus;

        ManaMinus = Mana.fillAmount - ManaCost/100f;

        Mana.fillAmount = ManaMinus;
            

    }


    void CooldownDisplay()
    {
        //Cooldown display

        if (SkillCooldown > -0.01f)
        {
            SkillCooldown -= Time.deltaTime;

            cooldownText.text = string.Format("{0:0}", SkillCooldown);

        }

        float currentMana = Mana.fillAmount;

        if (currentMana > ManaCost / 100f && SkillCooldown < 0.0f)
        {
            skillReady = true;

        }

        if (currentMana < ManaCost / 100f)
        {

            cooldownText.color = Color.blue;
            skillReady = false;
        }

        if (currentMana > ManaCost / 100f && cooldownText.color == Color.blue)
        {

            cooldownText.color = Color.white;
        }

    }

}
