using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerPoints playerPoints;

    private float damageBoost = 0f;
    private int collectableCounter = 0;
    private bool isGameWin = false;
    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        playerHealth.onPlayerHealthChange += GameOver;
    }

    private void OnDestroy()
    {
        playerHealth.onPlayerHealthChange -= GameOver;
    }

    public void SetCollectablePickedCounter()
    {
        collectableCounter++;

        GameWin();
    }

    private void GameWin()
    {
        if(collectableCounter == 3)
        {
            isGameWin = true;
        }
    }

    public bool GetIsGameWinState()
    {
        return isGameWin;
    }

    private void GameOver()
    {
        if (playerHealth.GetHealthValue() < 1)
        {
            isGameOver = true;
        }
    }

    public bool GetIsGameOverState()
    {
        return isGameOver;
    }

    public void ResetGameState()
    {
        isGameWin = false;
        isGameOver = false;
        collectableCounter = 0;
    }

    public void AddPlayerPoints(float pointsValue)
    {
        playerPoints.AddPlayerPoints(pointsValue);
    }

    public float GetPlayerPoints()
    {
        return playerPoints.GetPlayerPointsValue();
    }

    internal void AddPlayerHealth(float healthAmount)
    {
        playerHealth.AddHealth(healthAmount);
    }

    public void AddBoostDamage(float damageBoostAmount)
    {
        damageBoost += damageBoostAmount;
    }

    public float GetDamageBoost()
    {
        return damageBoost;
    }
}
