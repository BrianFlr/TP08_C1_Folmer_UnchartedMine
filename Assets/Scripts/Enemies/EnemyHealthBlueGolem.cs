using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBlueGolem : EnemiesHealth
{
    public event Action onBlueGolemDie;

    [SerializeField] private EnemiesDataSo blueGolemData;
    [SerializeField] private SoundEffectsDataSo sfxData;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject enemyDeathEffectPrefab;

    private float health = 0f;

    private void Start()
    {
        health = blueGolemData.orangeGolemHealth;
    }

    public override void ReceiveDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.fillAmount = health / blueGolemData.orangeGolemHealth;

        AudioManager.Instance.PlaySfx(sfxData.golemHurtSounds);
        Die();
    }

    private void Die()
    {
        if (health < 1)
        {
            onBlueGolemDie?.Invoke();

            Instantiate(enemyDeathEffectPrefab, transform.position, Quaternion.identity);
            AudioManager.Instance.PlaySfx(sfxData.golemDieSounds);

            gameObject.SetActive(false);
        }
    }
}
