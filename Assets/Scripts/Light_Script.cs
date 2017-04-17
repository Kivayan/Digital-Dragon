using UnityEngine;

public class Light_Script : MonoBehaviour
{
    public Light lt;
    private bool Darknes;

    // Use this for initialization
    private void Start()
    {
        Darknes = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Darknes)
        {
            if (lt.intensity > 2)
            {
                lt.intensity -= Time.deltaTime * 4;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Darknes = true;
    }
}