using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public event Action onPlayerHealthChange;

    [SerializeField] private PlayerDataSo playerData;

    private float maxHealth = 0f;
    private float health = 0f;

    private void Start()
    {
        maxHealth = playerData.health;
        health = playerData.health;
    }

    // Función para añadir vida.
    public void AddHealth(float healthAmount)
    {
        health = Mathf.Clamp(health + healthAmount, 0, maxHealth);

        onPlayerHealthChange?.Invoke();
    }

    // Función para recibir daño.
    public void ReceiveDamage(float damageAmount)
    {
        health -= damageAmount;

        onPlayerHealthChange?.Invoke();
    }

    public float GetHealthValue()
    {
        return health;
    }

    public float GetMaxHealthValue()
    {
        return maxHealth;
    }
}
