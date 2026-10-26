using UnityEngine;
using UnityEngine.UI;

public class UiButtonBack : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject activeCanvas;
    [SerializeField] private GameObject returnCanvas;

    [Header("Buttons")]
    [SerializeField] private Button btnBack;

    private void Awake()
    {
        btnBack.onClick.AddListener(OnBackClicked);
    }

    private void OnDestroy()
    {
        btnBack.onClick.RemoveAllListeners();
    }

    // Eventos de botones.
    private void OnBackClicked()
    {
        activeCanvas.SetActive(false);
        returnCanvas.SetActive(true);
    }
}
