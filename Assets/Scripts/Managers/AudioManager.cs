using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager Instance;

    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private AudioSource uiAudioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
