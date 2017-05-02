using System;
using UnityEngine;

namespace movementEngine
{
    public class Walk : MonoBehaviour, IMovement
    {
        public float speed = 6.0F;
        public float shiftSpeed;
        public float currentSpeed;
        public bool isSprinting = false;
        private AnimatorHandler anim;
        private bool movementBlocked = false;

        //good gravity and jumpspeed are 70/40
        public float jumpSpeed = 40;

        public float gravity = 65;
        private Vector3 moveDirection = Vector3.zero;

        private bool NormalizedRotation = true;
        private float timer = 0;

        [Range(20, 150)] public float mouseYSpeed = 50;

        private float YRotate = 0;
        private float XRotate = 0;
        private float XRotateNormalizeStartPoint;
        [Range(0, 5)] public float XBackToZeroSpeed;

        private void Start()
        {
            anim = GetComponent<AnimatorHandler>();
        }

        private void MonitorSpeed()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed = shiftSpeed;
                isSprinting = true;
            }
            else
            {
                isSprinting = false;
                currentSpeed = speed;
            }
        }

        public void Move()
        {
            ResetXRotation();

            if (!movementBlocked)
            {
                Walking();
                Rotate();
            }
            
            DebugInfo();
            MonitorSpeed();
        }

        private void Walking()
        {
            CharacterController controller = GetComponent<CharacterController>();
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= currentSpeed;

                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                    anim.isJumping = true;

                }

            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }

        private void Rotate()
        {
            YRotate += Input.GetAxis("Mouse X") * mouseYSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(new Vector3(XRotate, YRotate, 0));
        }

        private void DebugInfo()
        {
            DebugPanel.Log("WalkSpeed", "WalkParameters", speed);
            DebugPanel.Log("NormalizedRotation", "WalkSwitchParameters", NormalizedRotation);
            DebugPanel.Log("XRotateNormalizeStartPoint", "WalkSwitchParameters", XRotateNormalizeStartPoint);
        }

        //Ensures that if rotation in X is not set to 0 it will be lerped to 0.
        //This will happen in most scenarios where movement engine is changed from flying (which allows rotation in xAxis)
        private void ResetXRotation()
        {
            if (XRotate != 0 && NormalizedRotation == true)
            {
                Debug.Log("normalizing");
                NormalizedRotation = false;
                XRotateNormalizeStartPoint = XRotate;
            }

            if (NormalizedRotation == false)
            {
                timer += XBackToZeroSpeed * Time.deltaTime;
                XRotate = Mathf.Lerp(XRotateNormalizeStartPoint, 0, timer);
                if (XRotate == 0)
                {
                    NormalizedRotation = true;
                    timer = 0;
                }
            }
        }

        private void Land()
        {
        }

        void IMovement.SetCurrentRotation(Vector3 startingRotation)
        {
            XRotate = startingRotation.x;
            YRotate = startingRotation.y;
            movementBlocked = false;
        }

        Vector3 IMovement.GetCurrentRotation()
        {
            return new Vector3(XRotate, YRotate, transform.rotation.z);
        }

        public void EnableGravity()
        {
            throw new NotImplementedException();
        }

        public void DisableGravity()
        {
            throw new NotImplementedException();
        }

        public void BlockMovement()
        {
            movementBlocked = true;
        }
    }
}