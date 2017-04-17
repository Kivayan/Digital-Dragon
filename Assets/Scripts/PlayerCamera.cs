using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0F;
    private const float Y_ANGLE_MAX = 50.0f;
    public Transform lookAt;
    public Transform camTransform;

    // private Camera cam;

    private float distance = 50.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    //private float sensivityX = 4f;

    private void Start()
    {
        camTransform = transform;
        //cam = Camera.main;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0 - distance);
        Quaternion roration = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + roration * dir;
        camTransform.LookAt(lookAt.position);
    }
}