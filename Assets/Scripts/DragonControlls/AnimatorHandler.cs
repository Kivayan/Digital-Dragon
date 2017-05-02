using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class AnimatorHandler : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;

    private bool isMoving;
    public bool IsMoving { get { return isMoving; } }
    public bool isFlying = false;
    public bool isJumping = false;

    private bool isSprinting;
    public float speedMultiplierBase = 1f;
    public float speedMultiplierIncreased = 2f;
    public float animationDumpingSpeed;

    //-1 descending, 0 stationary, 1 ascending;
    private float verticalMovement = 0;
    private float horizontalMovement = 0;
    private float directionMovement = 0;

    //Jump can optionally have another name
    private string jump;

    private bool isDead = false;

    ///populate attackNames - they should match exactly Animator parameters
    ///this will serve as a reffernce, but code will validate if called name is contained within this list
    public List<string> attacks;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        DetectMovement();
        DetectMovementDirectionFly();
        DetectMovementDirectionWalkSides();
        DetectMovementDirectionWalkDirection();
        DebugInfo();
        DetectSpecificMovements();
    }

    private void DetectMovementDirectionFly()
    {
        if (isFlying)
        {
            float y = controller.velocity.y;

            if (y > 0)
                verticalMovement = 1;
            else if (y < 0)
                verticalMovement = -1;
            else
                verticalMovement = 0;

            anim.SetFloat("verticalMovement", verticalMovement, 1f, Time.deltaTime * animationDumpingSpeed);
        }
    }

    private void DetectMovementDirectionWalkSides()
    {
        
            if (Input.GetKey(KeyCode.D))
                horizontalMovement = 1;
            else if (Input.GetKey(KeyCode.A))
                horizontalMovement = -1;
            else
                horizontalMovement = 0;


            anim.SetFloat("horizontalMovement", horizontalMovement, 1f, Time.deltaTime * animationDumpingSpeed);

    }

    private void DetectMovementDirectionWalkDirection()
    {
        if (isFlying == false)
        {
            if (Input.GetKey(KeyCode.W))
                directionMovement = 0.5f;
            else if (Input.GetKey(KeyCode.S))
                directionMovement = -1;
            else
                directionMovement = 0;

            if (Input.GetKey(KeyCode.LeftShift))
                directionMovement = 1;

            anim.SetFloat("directionMovement", directionMovement, 1f, Time.deltaTime * animationDumpingSpeed);
        }
    }

    private void DetectSpecificMovements()
    {
        if (isFlying)
            anim.SetBool("isFlying", true);
        else
            anim.SetBool("isFlying", false);

        if (isJumping)
        {
            TriggerJump();
            isJumping = false;
        }
    }





    public void SpeedIncreased()
    {
        anim.SetFloat("speedMultiplier", speedMultiplierIncreased);
        isSprinting = true;
    }

    public void SpeedNormal()
    {
        anim.SetFloat("speedMultiplier", speedMultiplierBase);
        isSprinting = false;
    }

    public void TriggerDead()
    {
        isDead = true;
        anim.SetBool("isDead", isDead);
    }

    public void TriggerJump()
    {
            anim.SetTrigger("jump");
    }

    public void TriggerAttack(string attackName)
    {
        if (!attacks.Contains(attackName))
        {
            throw new Exception("Provided attack name is not valid:  " + attackName);
        }
        anim.SetTrigger(attackName);
    }

    private void DetectMovement()
    {
        if (controller.velocity == Vector3.zero)
            isMoving = false;
        else
            isMoving = true;

        anim.SetBool("isMoving", IsMoving);
    }

    private void DebugInfo()
    {
        DebugPanel.Log("isFlying", "anim", isFlying);
        DebugPanel.Log("isMoving", "anim", isMoving);
        DebugPanel.Log("verticalMovement", "anim", verticalMovement);
        DebugPanel.Log("horizontalMovement", "anim", horizontalMovement);
        DebugPanel.Log("directionMovement", "anim", directionMovement);

    }
}