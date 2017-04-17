using UnityEngine;

public class DragonController : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;
    private Rigidbody rb;

    private AudioSource effectAudio;

    public float rotateSpeed = 2;
    private float speed;
    public float normalspeed = 5;
    public float shiftSpeed = 12;
    public float jumphight = 10;
    public float jumpspeed = 10;
    public float currentStamina;
    public float gravity = 20f;

    private Vector3 movement = Vector3.zero;
    public GameObject UI;

    public ColliderController tailCollider1;
    public ColliderController tailCollider2;

    public ColliderController jawTop;
    public ColliderController jawBot;

    public ColliderController armLeft;
    public ColliderController armRight;

    public AudioClip audioTailHit;
    public AudioClip audioFistHit;
    public AudioClip audioEat;

    public bool eat;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        speed = normalspeed;
        effectAudio = GetComponentInChildren<AudioSource>();
    }

    private void Update()
    {
        currentStamina = UI.GetComponent<UI_Script>().CurrentStamin;
        Jump();
        Walk();
        //JumpAlternate();

        DetectMovement();
        TriggerAttacks();
        MonitorSpeed();
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
            armLeft.ColliderOn();
            armRight.ColliderOn();
            effectAudio.clip = audioFistHit;
            effectAudio.Play();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("HapTrigger");
            jawTop.ColliderOn();
            jawBot.ColliderOn();
            effectAudio.clip = audioEat;
            effectAudio.Play();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("TailTrigger");
            tailCollider1.ColliderOn();
            tailCollider2.ColliderOn();
            effectAudio.clip = audioTailHit;
            effectAudio.Play();
        }
    }

    private void MonitorSpeed()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (currentStamina > 10)   //TODO Nie mogę zrobić by w każdej sekundzie sprawdzał warunek
            {
                anim.SetBool("isSprinting", true);
                speed = shiftSpeed;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("isSprinting", false);
            speed = normalspeed;
        }
    }

    //not used ATM
    private void Jump()
    {
        if (controller.isGrounded)
        {
            movement.y = Physics.gravity.y * Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetTrigger("Jump");
                movement.y = jumpspeed;
            }
        }
        else
        {
            movement.y -= gravity * Time.deltaTime;
        }

        controller.Move(movement * Time.deltaTime);
    }

    public void TriggerDeathAnimation()
    {
        anim.SetTrigger("isDead");
    }

    public void TriggerDanceAnimation()
    {
        anim.SetBool("Dance", true);
    }

    public void EndDanceAnimation()
    {
        anim.SetBool("Dance", false);
    }

    /*  private void JumpAlternate()
      {
          if (controller.isGrounded == false)
          {
              movement.y += Physics.gravity.y * Time.deltaTime;
          }
          if (controller.isGrounded == true && Input.GetButton("Jump"))
          {
              Debug.Log(2);
              movement.y = jumpspeed;
          }
          controller.Move(movement * Time.deltaTime);
          Debug.Log(controller.isGrounded);
      }
      */
}