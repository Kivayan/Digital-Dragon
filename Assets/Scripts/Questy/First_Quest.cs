using UnityEngine;
using UnityEngine.UI;

public class First_Quest : MonoBehaviour
{
    public Text Quest;
    private bool Enter;
    private bool music;
    private float timer;

    // Use this for initialization
    private void Start()
    {
        Enter = false;
        Quest.GetComponent<Text>();
        music = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Enter)
        {
            if (music)
            {
                GetComponent<AudioSource>().Play();
                music = false;
            }
            timer += Time.deltaTime;
            Color N = Quest.color;
            if (timer < 2f)
            {
                N.a += Time.deltaTime * 5;
                Quest.color = N;
            }
            else if (timer > 2f)
            {
                N.a -= Time.deltaTime * 5;
                Quest.color = N;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Enter = true;
    }
}