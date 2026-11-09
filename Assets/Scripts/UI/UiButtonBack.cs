using UnityEngine;
using UnityEngine.UI;

public class UiButtonBack : MonoBehaviour
{
    [Header("Sound Data")]
    [SerializeField] private UiSoundDataSo soundData;

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
        AudioManager.Instance.PlayUi(soundData.buttonSound);

        activeCanvas.SetActive(false);
        returnCanvas.SetActive(true);
    }
}
