using UnityEngine;

public class JumpTest : MonoBehaviour
{
    private Rigidbody rb;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("dupakwas");
            rb.AddForce(Vector3.up * 500);
        }
    }
}