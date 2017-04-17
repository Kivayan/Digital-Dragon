using UnityEngine;

namespace movementEngine
{
    [RequireComponent(typeof(Flying))]
    [RequireComponent(typeof(Walk))]
    [RequireComponent(typeof(CharacterController))]
    public class MovementController : MonoBehaviour
    {
        private IMovement currentMovement;
        public IMovement walk;
        public IMovement fly;

        private Vector3 startingRotation;

        private CharacterController controller;

        [Range(0.2f, 4f)] public float awaitSecondSpaceTime;
        private float flyTriggerTimer = 0f;
        private bool awaitingSecondSpace = false;
        private bool startCount = false;

        private Timer flightStamina;
        private float flightStaminaCurrentValue;
        public float startStaminaValue;

        private void Start()
        {
            walk = GetComponent<Walk>();
            fly = GetComponent<Flying>();
            currentMovement = walk;
            currentMovement.SetCurrentRotation(new Vector3(0, 0, 0));
            flightStamina = new Timer(startStaminaValue);
            controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            flightStamina.TimerTracker();
            MonitorFly();
            SwitchMovementTypeSimple();
            currentMovement.Move();
            DebugInfo();
            // Debug.Log("Stamina = " + flightStaminaCurrentValue);
        }

        private void SwitchMovementTypeSimple()
        {
            if (Input.GetKeyDown(KeyCode.I))
                SwitchOnWalk();

            if (Input.GetKeyDown(KeyCode.K))
                SwitchOnFly();
        }

        private void MonitorFly()
        {
            flightStaminaCurrentValue = flightStamina.GetCurrentTimerValue();

            //When stamina is over, trurn on gravity and only on touchdown switch on walk
            if (flightStaminaCurrentValue <= 0 && currentMovement == fly)
            {
                if (controller.isGrounded != true)
                    fly.EnableGravity();
                else
                    SwitchOnWalk();
            }

            DoubleSpaceFlightTrigger();
        }

        private void DoubleSpaceFlightTrigger()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                startCount = true;

            if (flyTriggerTimer < awaitSecondSpaceTime & flyTriggerTimer > 0.2f)
                awaitingSecondSpace = true;

            if (flyTriggerTimer >= awaitSecondSpaceTime)
            {
                awaitingSecondSpace = false;
                startCount = false;
                awaitingSecondSpace = false;
                flyTriggerTimer = 0;
            }

            if (awaitingSecondSpace && Input.GetKeyDown(KeyCode.Space))
            {
                SwitchOnFly();
                startCount = false;
                awaitingSecondSpace = false;
                flyTriggerTimer = 0;
            }

            if (startCount == true)
                flyTriggerTimer += Time.deltaTime;
        }

        private void SwitchOnWalk()
        {
            Debug.Log("WalkOn");
            startingRotation = currentMovement.GetCurrentRotation();
            walk.SetCurrentRotation(startingRotation);
            currentMovement = walk;
        }

        private void SwitchOnFly()
        {
            Debug.Log("FlyOn");
            fly.DisableGravity();
            flightStamina.TimerOn();
            startingRotation = currentMovement.GetCurrentRotation();
            fly.SetCurrentRotation(startingRotation);
            currentMovement = fly;
        }

        private void DebugInfo()
        {
            DebugPanel.Log("Engine", "MoveEngineInfo", currentMovement);
            DebugPanel.Log("flyTriggerTimer", "FlySwitchProperties", flyTriggerTimer);
            DebugPanel.Log("awaitingSecondSpace", "FlySwitchProperties", awaitingSecondSpace);
            DebugPanel.Log("startCount", "FlySwitchProperties", startCount);
            DebugPanel.Log("StaminaCoundown", "FlightParameters", flightStaminaCurrentValue);
        }
    }
}