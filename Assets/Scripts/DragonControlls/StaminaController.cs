using UnityEngine;

public class StaminaController : MonoBehaviour
{
    public UI_Script UI;

    [SerializeField] private float maxStamina;
    [SerializeField] private float currentStamina;
    [SerializeField] private float refillRatePerSec;

    private bool allowRefill = true;
    private float tmpRefillRate = 1;

    private void Update()
    {
        //update UI Graphics
        UI.UpdateStaminaGraphic(currentStamina / maxStamina);
    }

    /// <summary>
    /// Substract from stamina as long as called. while called Refill will be blocked.
    /// Will not drop below 0.
    /// </summary>
    /// <param name="substractValuePerSec"></param>
    public void ContinousSubstract(float substractValuePerSec)
    {
        if (ValidateSufficientStamina(substractValuePerSec * Time.deltaTime))
        {
            allowRefill = false;
            currentStamina -= substractValuePerSec * Time.deltaTime;
        }
    }

    /// <summary>
    /// Prior to substraction it will be validated if curent stamina is sufficient for that operation. 
    /// It will return true when valid and false when invalid. Execute stamina-dependent only if result is true.
    /// </summary>
    /// <param name="valueToSubstract"> single substract value </param> 
    public bool SingleSubstract(float valueToSubstract)
    {
        if (ValidateSufficientStamina(valueToSubstract))
        {
            currentStamina -= valueToSubstract;
            return true;
        }
        else
            return false;
    }

    /// <summary>
    /// Will Refill Stamina to its max at given rate as long as called. 
    /// Will not be called if there is ongoning contionous substraction.
    /// </summary>
    /// <param name="refillRatePerSec"></param>
    public void RefillStamina()
    {
        if(currentStamina < maxStamina && allowRefill == true)
        {
            currentStamina += 1 * Time.deltaTime * refillRatePerSec;
        }

        allowRefill = true;
    }

    public void SetRefillRate(float valueToSet)
    {
        refillRatePerSec = valueToSet;
    }

    public void AddToRefillRate(float valueToAdd)
    {
        refillRatePerSec += valueToAdd;
    }

    public void SubstractFromRefillRate(float valueToSubstract)
    {
        if (valueToSubstract <= refillRatePerSec)
            refillRatePerSec -= valueToSubstract;
        else
            refillRatePerSec = 0;
    }

    public void DisableRefill()
    {
        tmpRefillRate = refillRatePerSec;
        refillRatePerSec = 0;
    }

    public void EnableRefill()
    {
        refillRatePerSec = tmpRefillRate;
    }

    public void EnableRefill(float refillRatePerSec)
    {
        this.refillRatePerSec = refillRatePerSec;
    }

    /// <summary>
    /// Adds value to maxStamina, does not influence currentStamina
    /// </summary>
    /// <param name="valueToAdd"></param>
    public void AddToStaminaMax(float valueToAdd)
    {
        maxStamina += valueToAdd;
    }

    /// <summary>
    /// Add value to current Stamina. Will not exced maxStamina
    /// </summary>
    /// <param name="valueToAdd"></param>
    public void AddToStaminaTemp(float valueToAdd)
    {
        if (currentStamina + valueToAdd <= maxStamina)
            currentStamina += valueToAdd;
        else
            currentStamina = maxStamina;
    }

    /// <summary>
    /// Returns Current Stamina
    /// </summary>
    /// <returns></returns>
    public float GetCurrentStamina()
    {
        return currentStamina;
    }

    /// <summary>
    /// Constructor - will assign maxStamina,and set CurrentStamina to Max.
    /// </summary>
    /// <param name="maxStamina"></param>
    public StaminaController(float maxStamina, float refillRatePerSec)
    {
        this.maxStamina = maxStamina;
        this.refillRatePerSec = refillRatePerSec;
        currentStamina = maxStamina;
    }

    private bool ValidateSufficientStamina(float valueToSubstract)
    {
        if (valueToSubstract <= currentStamina)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}