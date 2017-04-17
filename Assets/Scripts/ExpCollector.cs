using UnityEngine;
using UnityEngine.UI;

public class ExpCollector : MonoBehaviour
{
    private int totalExp;
    public Text expText;
    public Transform gameControler;

    private void Start()
    {
        totalExp = 0;
        UpdateText();
        gameControler = GameObject.FindGameObjectWithTag("GameControler").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exp"))
        {
            Debug.Log("Exp Collected");
            int newExp = other.gameObject.GetComponent<Experience>().expValue;
            totalExp += newExp;
            UpdateText();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("EndGame"))
        {
            Debug.Log("END GAME");
            int newExp = other.gameObject.GetComponent<Experience>().expValue;
            totalExp += newExp;
            UpdateText();
            gameControler.GetComponent<GameOver>().EndGame();
            Destroy(other.gameObject);
        }

    }

    private void UpdateText()
    {
        expText.text = " UR EXP IZ = " + totalExp;
    }
}