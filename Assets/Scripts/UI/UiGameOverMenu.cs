using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiGameOverMenu : MonoBehaviour
{
    [Header("Canvas GameOver")]
    [SerializeField] private GameObject canvasGameOver;

    [Header("Canvas GameOver Text")]
    [SerializeField] private TMP_Text textPlayerPoints;

    [Header("Buttons")]
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnExit;

    private void Awake()
    {
        btnRestart.onClick.AddListener(OnRestartClicked);
        btnExit.onClick.AddListener(OnExitClicked);
    }

    private void Update()
    {
        /*if (GameManager.Instance.GetIsGameOverState())
        {
            GameOver();
        }*/
    }

    private void OnDestroy()
    {
        btnRestart.onClick.RemoveAllListeners();
        btnExit.onClick.RemoveAllListeners();
    }

    private void GameOver()
    {
        // Detengo el juego.
        Time.timeScale = 0;

        // Muestro los puntos del player.
        textPlayerPoints.text = GameManager.Instance.GetPlayerPoints().ToString("0");

        // Activo el canvas de ganar o perder.
        canvasGameOver.SetActive(true);
    }

    // Eventos de botones
    private void OnRestartClicked()
    {
        // Reanudo el tiempo del juego
        Time.timeScale = 1;

        // Reseteo la escena Gameplay
        SceneManager.LoadScene("Gameplay");

        // Desactivo el panel de GameOver
        canvasGameOver.SetActive(false);

        GameManager.Instance.ResetGameState();
    }

    private void OnExitClicked()
    {
        // Reanudo el tiempo del juego
        Time.timeScale = 1;

        // Desactivo el panel de GameOver
        canvasGameOver.SetActive(false);

        // Cargo la escena "MainMenu"
        SceneManager.LoadScene("MainMenu");

        GameManager.Instance.ResetGameState();
    }
}
