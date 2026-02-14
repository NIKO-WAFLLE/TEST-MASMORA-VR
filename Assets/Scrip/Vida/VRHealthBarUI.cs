using UnityEngine;
using UnityEngine.UI;

public class VRHealthBarUI : MonoBehaviour
{
    public VRPlayerHealth playerHealth;
    public Image healthFillImage;

    private void Update()
    {
        if (playerHealth == null || healthFillImage == null)
            return;

        float fillAmount = playerHealth.GetCurrentHealth() / playerHealth.maxHealth;
        healthFillImage.fillAmount = fillAmount;
    }
}
