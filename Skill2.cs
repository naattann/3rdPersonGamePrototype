using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skill2 : MonoBehaviour
{

    public TextMeshProUGUI cooldownText;
    public Slider loadingSpell;

    public Camera Cam;
    public Transform attackPoint;
    public GameObject bullet;

    public float shootForce;
    public float upwardForce;

    public Image Mana;

    [SerializeField] float Cooldown;
    [SerializeField] float ManaCost;
   
    public LayerMask Enemy;

    public float maxCastingTime;    
    private bool skillReady;
    private float castingTime;
    private float SkillCooldown;
   
    public float damage;
    public float damageModifier;

    public bool castFinished;
    public bool ManaCoolDone;


    void Start()
    {

        castFinished = false;
        ManaCoolDone = false;

       
        skillReady = true;
        loadingSpell.gameObject.SetActive(false);

    }

    
    void Update()
    {

      
        if (Input.GetKey(KeyCode.Alpha2) == true && skillReady == true)
        {          
            Cast();
        }


        if (Input.GetKeyUp(KeyCode.Alpha2) == true && skillReady == true)
        {
            Shoot();

            castingTime = 0.0f;  //reseting spell cast value

            CooldownMana();                   
        }



        CooldownDisplay();


    }


    void Cast()
    {

         loadingSpell.gameObject.SetActive(true);
         
         castingTime += Time.deltaTime;

         loadingSpell.value = castingTime / maxCastingTime;

    }


    void CooldownMana()
    {

        SkillCooldown = Cooldown;      

        float ManaMinus;

        ManaMinus = Mana.fillAmount - ManaCost / 100f;

        Mana.fillAmount = ManaMinus;

        loadingSpell.value = 0.0f;

        loadingSpell.gameObject.SetActive(false);

        skillReady = false;
    }


    void Shoot()
    {
                     
        damage = damageModifier * castingTime / maxCastingTime;

        
        Ray ray = Cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Just a ray through the middle of your current view
        RaycastHit hit;


        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //Just a point far away from the player

        //Calculate direction from attackPoint to targetPoint
        Vector3 direction = targetPoint - attackPoint.position;

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(attackPoint.transform.up * upwardForce, ForceMode.Impulse);


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
