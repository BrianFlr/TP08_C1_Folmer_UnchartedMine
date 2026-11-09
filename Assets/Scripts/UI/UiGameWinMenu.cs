using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiGameWinMenu : MonoBehaviour
{
    [Header("Audio Data")]
    [SerializeField] private UiSoundDataSo uiSoundData;
    [SerializeField] private MusicDataSo musicData;

    [Header("Canvas GameOver")]
    [SerializeField] private GameObject canvasGameWin;

    [Header("Canvas GameOver Text")]
    [SerializeField] private TMP_Text textMaxPlayerPoints;
    [SerializeField] private TMP_Text textPlayerPoints;

    [Header("Buttons")]
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnExit;

    private void Awake()
    {
        btnRestart.onClick.AddListener(OnRestartClicked);
        btnExit.onClick.AddListener(OnExitClicked);
    }

    private void Start()
    {
        // Lo suscribo en el start porque el orden de ejecución hacía que el game manager se creara después que el canvas.
        GameManager.Instance.onGameWin += GameWin;
    }

    private void OnDestroy()
    {
        btnRestart.onClick.RemoveAllListeners();
        btnExit.onClick.RemoveAllListeners();

        GameManager.Instance.onGameWin -= GameWin;
    }

    private void GameWin()
    {
        // Detengo el juego.
        Time.timeScale = 0;

        // Muestro los puntos del player.
        textMaxPlayerPoints.text = GameManager.Instance.GetMaxPlayerPoints().ToString("0");
        textPlayerPoints.text = GameManager.Instance.GetPlayerPoints().ToString("0");

        // Activo el canvas de ganar o perder.
        canvasGameWin.SetActive(true);

        AudioManager.Instance.PlayMusic(musicData.gameWinMusic, false);
    }

    // Eventos de botones
    private void OnRestartClicked()
    {
        // Reanudo el tiempo del juego
        Time.timeScale = 1;

        // Reseteo la escena Gameplay
        SceneManager.LoadScene("Gameplay");

        // Desactivo el panel de GameOver
        canvasGameWin.SetActive(false);

        GameManager.Instance.ResetGameState();

        AudioManager.Instance.PlayUi(buttonSounds);
        AudioManager.Instance.PlayMusic(musicData.gameplayMusic, true);
    }

    private void OnExitClicked()
    {
        // Reanudo el tiempo del juego
        Time.timeScale = 1;

        // Desactivo el panel de GameOver
        canvasGameWin.SetActive(false);

        // Cargo la escena "MainMenu"
        SceneManager.LoadScene("MainMenu");

        GameManager.Instance.ResetGameState();

        AudioManager.Instance.PlayMusic(musicData.mainMenuMusic, true);
    }
}
