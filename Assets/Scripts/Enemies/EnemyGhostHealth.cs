using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGhostHealth : MonoBehaviour
{
    public event Action onGhostDie;

    [SerializeField] private EnemiesDataSo ghostData;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject enemyDeathEffectPrefab;

    private float health = 0f;

    private void Start()
    {
        health = ghostData.ghostHealth;
    }

    // Función para recibir daño.
    public void ReceiveDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.fillAmount = health / ghostData.ghostHealth;

        Die();
    }

    private void Die()
    {
        if (health < 1)
        {
            onGhostDie?.Invoke();

            Instantiate(enemyDeathEffectPrefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
