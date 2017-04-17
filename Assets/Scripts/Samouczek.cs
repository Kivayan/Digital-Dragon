using UnityEngine;
using UnityEngine.UI;

public class Samouczek : MonoBehaviour
{
    public Text tutorial;
    private bool Enter;

    // Use this for initialization
    private void Start()
    {
        Enter = false;
        tutorial.GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        Color N = tutorial.color;
        if (Enter)
        {
            N.a += Time.deltaTime * 10f;
            tutorial.color = N;
        }
        else if (!Enter && N.a > 0)
        {
            N.a -= Time.deltaTime * 10f;
            tutorial.color = N;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Enter = true;
        Debug.Log("kupa");
    }

    private void OnTriggerExit(Collider other)
    {
        Enter = false;
    }
}