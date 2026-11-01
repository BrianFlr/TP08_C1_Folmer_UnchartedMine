using UnityEngine;
using UnityEngine.UI;

public class UiPlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image fillHealthBar;

    private void Awake()
    {
        playerHealth.onPlayerHealthChange += UpdateHealthBarFill;
    }

    private void OnDestroy()
    {
        playerHealth.onPlayerHealthChange -= UpdateHealthBarFill;
    }

    private void UpdateHealthBarFill()
    {
        fillHealthBar.fillAmount = playerHealth.GetHealthValue() / playerHealth.GetMaxHealthValue();
    }
}
