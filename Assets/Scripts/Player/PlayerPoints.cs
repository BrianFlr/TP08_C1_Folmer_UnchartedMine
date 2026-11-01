using System;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public event Action onPlayerPointsChange;
    private float playerPoints = 0f;

    // Función para añadir puntos.
    public void AddPlayerPoints(float pointsAmount)
    {
        playerPoints += pointsAmount;

        onPlayerPointsChange?.Invoke();
    }

    public float GetPlayerPointsValue()
    {
        return playerPoints;
    }
}
