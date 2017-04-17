using System.Collections;
using UnityEngine;

public class FractureDestroyer : MonoBehaviour
{
    private MeshCollider[] fracColls;
    public float timeToDisappear = 5;

    // Use this for initialization
    private void Start()
    {
        fracColls = GetComponentsInChildren<MeshCollider>();
        StartCoroutine(turnOfColl(fracColls));
        Destroy(gameObject, timeToDisappear + 3);
    }

    private IEnumerator turnOfColl(MeshCollider[] colliders)
    {
        yield return new WaitForSeconds(timeToDisappear);

        foreach (var f in colliders)
        {
            f.enabled = false;
        }
    }
}