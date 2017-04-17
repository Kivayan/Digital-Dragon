using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    public float TotalHp;
    public float CurrentHp;

    public float TotalStamina;
    public float CurrentStamin;
    public float SprintCost;
    public float JumpCost;

    public GameObject player;

    public Image damageImage;
    public Slider staminaSlider;
    public Slider healthSlider;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public Text QuestName;
    public Text QestDetal;

    private bool damage;

    // Use this for initialization
    private void Start()
    {
        
        CurrentHp = TotalHp;
        QestDetal.GetComponent<Text>();
        QuestName.GetComponent<Text>();
        CurrentStamin = TotalStamina;
    }

    // Update is called once per frame
    private void Update()
    {
        //Obsluga paska z Queste
        if (Input.GetKey(KeyCode.Tab))
        {
            Color N = QuestName.color;
            Color C = QestDetal.color;
            C.a += Time.deltaTime * 5;
            N.a += Time.deltaTime * 5;
            QuestName.color = N;
            QestDetal.color = C;
        }
        else
        {
            Color N = QuestName.color;
            Color C = QestDetal.color;
            C.a -= Time.deltaTime;
            N.a -= Time.deltaTime;
            QuestName.color = N;
            QestDetal.color = C;
        }

        /*
        //Obsługa Staminy
        if (Input.GetKey(KeyCode.LeftShift) && CurrentStamin > 0)
        {
            CurrentStamin -= SprintCost;
            staminaSlider.value = CurrentStamin;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && CurrentStamin > 0)
        {
            CurrentStamin -= JumpCost;
            staminaSlider.value = CurrentStamin;
        }
        else
        {
            if (CurrentStamin < 100)
            {
                CurrentStamin += Time.deltaTime + 0.5f;
                staminaSlider.value = CurrentStamin;
            }
        }
        */

        if (damage)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damage = false;

        if(CurrentHp <= 0)
        {
            player.GetComponent<DragonController>().TriggerDeathAnimation();
            player.GetComponent<CharacterController>().enabled = false;
        }
    }

    public void TakeDamage(int amount)
    {
        damage = true;
        CurrentHp -= amount;
        healthSlider.value = CurrentHp;
    }

    public void GetHeal(int amount)
    {
        CurrentHp += amount;
        healthSlider.value = CurrentHp;
    }

    public void UpdateStaminaGraphic(float staminaPercentageValue)
    {
        staminaSlider.value = staminaPercentageValue;
    }
}