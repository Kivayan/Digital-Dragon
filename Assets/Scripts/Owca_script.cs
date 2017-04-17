using UnityEngine;

public class Owca_script : MonoBehaviour
{
    public bool eat;
    public GameObject UI;
    public int hprestor;
    public float timer;

    // Use this for initialization
    private void Start()
    {
        eat = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (eat)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                eat = false;
                timer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && eat)
        {
            UI.GetComponent<UI_Script>().GetHeal(hprestor);
            Destroy(gameObject);
        }
    }
}