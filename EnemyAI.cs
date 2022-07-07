using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{

    public Animator animator;

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask groundMask, playerMask;


    public Image PlayerhealthBar;
    // Patroling

    public Vector3 walk;
    bool walkSet;
    public float walkRange;


    public bool isBurning = false;
    //HP


    public bool isFireResistant;

    //Attacking


    public bool alreadyAttacked = false;
    [SerializeField] float damage;
    
    

    //States


    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();





    }

    // Update is called once per frame
    void Update()
    {

      


        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) Chasing();
        if (playerInSightRange && playerInAttackRange) Attacking();


       
         

    }



    private void Patroling()
    {


        animator.SetInteger("Condition", 0);

        if (!walkSet) SearchWalk();


        if (walkSet)
            agent.SetDestination(walk);

        Vector3 distanceToWalkPoint = transform.position - walk;

        if (distanceToWalkPoint.magnitude < 1f)
            walkSet = false;



    }

    private void SearchWalk()
    {



        float randomZ = Random.Range(-walkRange, walkRange);
        float randomX = Random.Range(-walkRange, walkRange);

        walk = new Vector3((transform.position.x + randomX) / 4f, transform.position.y, (transform.position.z + randomZ) / 4f);

        if (Physics.Raycast(walk, -transform.up, 2f, groundMask))

            walkSet = true;


    }

    private void Chasing()
    {

        animator.SetInteger("Condition", 1);
        agent.SetDestination(player.position);





    }
    private void Attacking()
    {

        animator.SetInteger("Condition", 2);
        agent.SetDestination(player.position);
        




        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 > 0.45f && animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 < 0.55f && alreadyAttacked == false && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") == true)
            {

            player.GetComponent<Health>().healthValue -= damage / 100f;
       
           
            alreadyAttacked = true;
            

        }

       if (alreadyAttacked == true && animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") == true)
        {

            ResetAttack();
        }

    }


    public void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
