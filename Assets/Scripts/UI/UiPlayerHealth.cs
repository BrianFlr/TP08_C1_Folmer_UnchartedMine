using UnityEngine;
using UnityEngine.UI;

public class UiPlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image fillHealthBar;

    private float maxHealth = 0f;

    private void Awake()
    {
        //playerHealth.onPlayerHealthChange += UpdateHealthBarFill;
    }

    private void Start()
    {
        //maxHealth = playerHealth.GetMaxHealthValue();
    }

    private void OnDestroy()
    {
        //playerHealth.onPlayerHealthChange -= UpdateHealthBarFill;
    }

    private void UpdateHealthBarFill()
    {
        fillHealthBar.fillAmount = playerHealth.GetHealthValue() / maxHealth;
    }
}
