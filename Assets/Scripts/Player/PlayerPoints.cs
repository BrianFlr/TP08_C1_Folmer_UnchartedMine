using System;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public event Action onPlayerPointsChange;
    private float playerPoints = 0f;
    private float maxPlayerPoints = 0f;
    private const string MAX_SCORE = "PlayerMaxScore";

    private void Start()
    {
        maxPlayerPoints = PlayerPrefs.GetFloat(MAX_SCORE);
    }

    // Función para añadir puntos.
    public void AddPlayerPoints(float pointsAmount)
    {
        playerPoints += pointsAmount;

        onPlayerPointsChange?.Invoke();
    }

    public void SaveMaxScorePrefs()
    {
        if (playerPoints > maxPlayerPoints)
        {
            maxPlayerPoints = playerPoints;
            PlayerPrefs.SetFloat(MAX_SCORE, playerPoints);
        }
    }

    public float GetPlayerPointsValue()
    {
        return playerPoints;
    }

    public float GetMaxPlayerPointsValue()
    {
        return maxPlayerPoints;
    }
}
