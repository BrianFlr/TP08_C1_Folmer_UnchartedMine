using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMainMenu : MonoBehaviour
{
    [Header("Sound Data")]
    [SerializeField] private UiSoundDataSo uiSoundData;
    [SerializeField] private MusicDataSo musicData;

    [Header("Canvas")]
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject creditsCanvas;

    [Header("Buttons")]
    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnCredits;
    [SerializeField] private Button btnExit;

    private void Awake()
    {
        btnStart.onClick.AddListener(OnStartClicked);
        btnSettings.onClick.AddListener(OnSettingsClicked);
        btnCredits.onClick.AddListener(OnCreditsClicked);
        btnExit.onClick.AddListener(OnExitClicked);
    }

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        btnExit.gameObject.SetActive(false);
#endif
    }

    private void OnDestroy()
    {
        btnStart.onClick.RemoveAllListeners();
        btnSettings.onClick.RemoveAllListeners();
        btnCredits.onClick.RemoveAllListeners();
        btnExit.onClick.RemoveAllListeners();
    }

    // Eventos de botones
    private void OnStartClicked()
    {
        AudioManager.Instance.PlayUi(uiSoundData.buttonSound);
        AudioManager.Instance.PlayMusic(musicData.gameplayMusic, true);

        // Cargo la escena de juego
        SceneManager.LoadScene("Gameplay");
    }

    private void OnSettingsClicked()
    {
        AudioManager.Instance.PlayUi(uiSoundData.buttonSound);

        // Activo el canvas settings
        settingsCanvas.SetActive(true);
    }

    private void OnCreditsClicked()
    {
        AudioManager.Instance.PlayUi(uiSoundData.buttonSound);

        // Activo el canvas credits
        creditsCanvas.SetActive(true);
    }

    private void OnExitClicked()
    {
        AudioManager.Instance.PlayUi(uiSoundData.buttonSound);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
