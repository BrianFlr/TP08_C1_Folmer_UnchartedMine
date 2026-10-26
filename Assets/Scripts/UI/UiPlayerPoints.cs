using TMPro;
using UnityEngine;

public class UiPlayerPoints : MonoBehaviour
{
    [SerializeField] private PlayerPoints playerPoints;

    [Header("Canvas Player Points Text")]
    [SerializeField] private TMP_Text textPoints;

    private void Awake()
    {
        playerPoints.onPlayerPointsChange += ShowPlayerPoints;
    }

    private void OnDestroy()
    {
        playerPoints.onPlayerPointsChange += ShowPlayerPoints;
    }

    private void ShowPlayerPoints()
    {
        // Muestro los puntos del player
        textPoints.text = playerPoints.GetPlayerPointsValue().ToString("0");
    }
}
