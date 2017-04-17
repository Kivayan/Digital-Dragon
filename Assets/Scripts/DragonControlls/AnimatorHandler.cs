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

    private bool isSprinting;
    public float speedMultiplierBase = 1f;
    public float speedMultiplierIncreased = 2f;

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
        if (jump != null || jump != "")
            anim.SetTrigger(jump);
        else
            anim.SetTrigger("jump");
    }

    public void TriggerAttack(string attackName)
    {
        if (!attacks.Contains(attackName))
        {
            throw new Exception("Provided attack name is not valid " + attackName);
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
}