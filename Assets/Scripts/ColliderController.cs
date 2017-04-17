using System.Collections;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    private Collider coll;
    [SerializeField] private float colliderOnDuration = 2f;

    private void Start()
    {
        coll = GetComponent<Collider>();
        coll.enabled = false;
    }

    public void ColliderOn()
    {
        StartCoroutine(TimedEnable());
    }

    private IEnumerator TimedEnable()
    {
        coll.enabled = true;
        //Debug.Log("collider Enabled");
        yield return new WaitForSeconds(colliderOnDuration);

        coll.enabled = false;
        //Debug.Log("collider Disabled");
    }
}