using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject player;
    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;
    private PlayerMeleeAttack playerMeleeAttack;
    private PlayerImmortality playerImmortality;
    private PlayerPoints playerPoints;

    private bool dynamitePackPicked = false;
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

        playerMovement = player.GetComponent<PlayerMovement>();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMeleeAttack = player.GetComponent<PlayerMeleeAttack>();
        playerImmortality = player.GetComponent<PlayerImmortality>();
        playerPoints = player.GetComponent<PlayerPoints>();

        playerHealth.onPlayerHealthChange += GameOver;
    }

    private void OnDestroy()
    {
        playerHealth.onPlayerHealthChange -= GameOver;
    }

    public void GameWin()
    {
        isGameWin = true;
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

            playerPoints.SaveMaxScorePrefs();
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
        dynamitePackPicked = false;
    }

    public void ActivateDoubleJump()
    {
        playerMovement.ActivateDoubleJump();
    }

    public void AddPlayerHealth(float healthAmount)
    {
        playerHealth.AddHealth(healthAmount);
    }

    public void SetMeleeDamage(float damageMeleeAmount)
    {
        playerMeleeAttack.SetMeleeDamage(damageMeleeAmount);
    }

    public void ActivatePlayerImmortality(float time)
    {
        playerImmortality.ActivateImmortality(time);
    }

    public void AddPlayerPoints(float pointsValue)
    {
        playerPoints.AddPlayerPoints(pointsValue);
    }

    public float GetPlayerPoints()
    {
        return playerPoints.GetPlayerPointsValue();
    }

    public float GetMaxPlayerPoints()
    {
        return playerPoints.GetMaxPlayerPointsValue();
    }

    public void SetDynamitePack(bool state)
    {
        dynamitePackPicked = state;
    }

    public bool GetDynamitePackPickedState()
    {
        return dynamitePackPicked;
    }
}
