using UnityEngine;

public class StamniaTester : MonoBehaviour
{
    private StaminaController stamina;
    public float spaceStaminaSubstract;

    public bool lastSubstractSuccess;
    public float continousSubstractRatePerSec;

    private void Start()
    {
        stamina = new StaminaController(50,1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lastSubstractSuccess = stamina.SingleSubstract(spaceStaminaSubstract);
        }

        if (Input.GetKey(KeyCode.B))
        {
            stamina.ContinousSubstract(continousSubstractRatePerSec);
        }

        DebugInfo();
        stamina.RefillStamina();
    }

    private void DebugInfo()
    {
       // DebugPanel.Log("MaxStamina", stamina.maxStamina);
        DebugPanel.Log("CurrentStamina", stamina.GetCurrentStamina());
       // DebugPanel.Log("allowRefil", stamina.allowRefill);
    }
}