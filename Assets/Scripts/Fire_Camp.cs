using UnityEngine;

public class Fire_Camp : MonoBehaviour
{
    public GameObject HealBar;
    private float Minimal_HP;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        Minimal_HP = HealBar.GetComponent<UI_Script>().CurrentHp;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (Minimal_HP > 0)
            HealBar.GetComponent<UI_Script>().TakeDamage(5);
    }
}