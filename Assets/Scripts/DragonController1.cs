using UnityEngine;

public class DragonController1 : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;
    private Rigidbody rb;
    public float rotateSpeed = 2;
    private float speed;
    public float normalspeed = 5;
    public float shiftSpeed = 12;
    public float jumphight = 10;
    public float jumpspeed = 10;
    public float currentStamina;

    // private Vector3 movement = Vector3.zero;
    public GameObject UI;

    public GameObject owca;

    public bool eat;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    private void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        speed = normalspeed;

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    private void Update()
    {
        currentStamina = UI.GetComponent<UI_Script>().CurrentStamin;
        Walk();
        //JumpAlternate();

        DetectMovement();
        TriggerAttacks();
        MonitorSpeed();
        JumpMonitor();
    }

    private void Walk()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
    }

    private void DetectMovement()
    {
        if (controller.velocity == Vector3.zero)
        {
            anim.SetInteger("MovementPhase", 0);
        }
        else
        {
            anim.SetInteger("MovementPhase", 1);
        }
    }

    private void TriggerAttacks()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("CapTrigger");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("HapTrigger");
            owca.GetComponent<Owca_script>().eat = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("TailTrigger");
        }
    }

    private void MonitorSpeed()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (currentStamina > 10)   //TODO Nie mogę zrobić by w każdej sekundzie sprawdzał warunek
            {
                anim.SetFloat("SpeedMultiplier", 2.0f);
                speed = shiftSpeed;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetFloat("SpeedMultiplier", 1.0f);
            speed = normalspeed;
        }
    }

    private void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void JumpMonitor()
    {
        if (Input.GetKeyDown(KeyCode.Space))//&& isGrounded)
        {
            Debug.Log("Jump");
            rb.AddForce(Vector3.up * 500);
        }
    }
}