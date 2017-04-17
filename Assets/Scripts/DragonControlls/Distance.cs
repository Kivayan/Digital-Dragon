using UnityEngine;

namespace movementEngine
{
    public class Distance : MonoBehaviour
    {
        private RaycastHit rayHit;
        private Ray ray;

        private float distance;

        private void Start()
        {
            ray = new Ray(transform.position, Vector3.down);
        }

        private void Update()
        {
            CalculateDist();
        }

        private void CalculateDist()
        {
            if (Physics.Raycast(transform.position, Vector3.down, out rayHit))
            {
                distance = rayHit.distance;
            }
            Debug.DrawRay(transform.position, Vector3.down);
        }

        public float GetCurrentDistance()
        {
            return distance;
        }
    }
}