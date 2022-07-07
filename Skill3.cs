using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skill3 : MonoBehaviour
{

    public TextMeshProUGUI cooldownText;

    public Image Mana;
    [SerializeField] float Cooldown;
    [SerializeField] float ManaCost;


    public GameObject hitExplosion;
    public Camera Cam;
    // Start is called before the first frame update

    public LayerMask Enemy;

    private bool skillReady;

    public float range;
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

        if (Input.GetKeyDown(KeyCode.Alpha3) == true && skillReady == true)
        {
            Cast();

            CooldownMana();

        }

        CooldownDisplay();

    }

    void Cast()
    {


        Ray ray = Cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Just a ray through the middle of your current view
        RaycastHit hit;


        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("floor") == true)
            targetPoint = hit.point;
        else
        {
            return;
        }


        Collider[] enemiesHit = Physics.OverlapSphere(targetPoint, range, Enemy);


        Instantiate(hitExplosion, targetPoint, Quaternion.identity);


        foreach (var enemyHit in enemiesHit)
        {
            enemyHit.GetComponent<DestroyEnemy>().HP -= damage;

            Vector3 direction = (enemyHit.transform.position - gameObject.transform.position).normalized;

            enemyHit.GetComponent<Rigidbody>().AddForce(direction * knockForce, ForceMode.Impulse);

        }

    }


    void CooldownMana()
    {
        SkillCooldown = Cooldown;

        skillReady = false;

        float ManaMinus;

        ManaMinus = Mana.fillAmount - ManaCost / 100f;

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
