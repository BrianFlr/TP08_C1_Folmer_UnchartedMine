using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public event Action onPlayerHealthChange;

    [SerializeField] private PlayerDataSo playerData;
    private PlayerImmortality playerImmortality;

    [SerializeField] private float maxHealth = 0f;
    [SerializeField] private float health = 0f;
    private float invulnerabilityTime = 0f;

    private void Awake()
    {
        playerImmortality = GetComponent<PlayerImmortality>();
    }

    private void Start()
    {
        maxHealth = playerData.health;
        health = playerData.health;

        invulnerabilityTime = playerData.invulnerabilityTime;
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

        playerImmortality.ActivateImmortality(invulnerabilityTime);

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
