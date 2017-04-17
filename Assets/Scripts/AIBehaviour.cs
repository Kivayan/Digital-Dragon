using UnityEngine;
using UnityEngine.AI;

public class AIBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public float AISpeed;
    public Transform player;
    public bool targetVisible = false;
    public UI_Script healthBar;
    public float speedAtack;
    public int dmg = 5;

    public float attackDistance = 30;
    private float timer;
    private Animator anim;

    public bool testUnit = false;

    public float distToTgt;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = AISpeed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponentInChildren<Animator>();
        healthBar = FindObjectOfType<UI_Script>();
    }

    private void Update()
    {
        MonitorTarget();
        Attack();
        DetectMovement();
    }

    private void DetectMovement()
    {
        if (anim != null)
        {
            if (agent.velocity == Vector3.zero)
            {
                anim.SetBool("isMoving", false);
            }
            else
            {
                anim.SetBool("isMoving", true);
            }
        }
    }

    private void MonitorTarget()
    {
        distToTgt = Vector3.Distance(transform.position, player.position);

        if (targetVisible == true && distToTgt > 20)
            agent.SetDestination(player.position);
    }

    private void Attack()
    {
        if (distToTgt <= attackDistance)
        {
            agent.speed = 0;
            int x = Random.Range(1, 4);

            //ensures no errors after soldier is destroyed
            if (anim != null)
                anim.SetInteger("Attack", x);

            timer += Time.deltaTime;
            if (timer > speedAtack)
            {
                healthBar.TakeDamage(dmg);
                timer = 0f;
            }
        }
        else
        {
            agent.speed = AISpeed;
            timer = speedAtack;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            targetVisible = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            targetVisible = false;
        }
    }

  /*  private void OnGUI()
    {
        if (testUnit)
            GUI.TextArea(new Rect(10, 100, 100, 100),
            "timer = " + timer
            + "\nSpeed = " + agent.speed
            + "\nagentVelocity = " + agent.velocity
            );
    }*/
}