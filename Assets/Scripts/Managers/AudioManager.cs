using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private MusicDataSo musicData; 
    [SerializeField] private SoundEffectsDataSo sfxData;
    [SerializeField] private UiSoundDataSo uiData; 

    [SerializeField] private AudioSource musicAudioSource;
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

    private void Start()
    {
        PlayMusic(musicData.mainMenuMusic, true);
    }

    public void PlayMusic(AudioClip audioClip, bool loop)
    {
        if (musicAudioSource.clip == audioClip && musicAudioSource.isPlaying) return;

        musicAudioSource.clip = audioClip;
        musicAudioSource.loop = loop;
        musicAudioSource.Play();
    }

    public void PlayUi(AudioClip audioClip)
    {
        uiAudioSource.PlayOneShot(audioClip);
    }

    public void PlaySfx(AudioClip[] sfxList)
    {
        AudioClip clip = sfxList[Random.Range(0, sfxList.Length)];
        sfxAudioSource.PlayOneShot(clip);
    }
}
