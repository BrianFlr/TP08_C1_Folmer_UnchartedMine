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

    public void PlayMusic(AudioClip audioClip)
    {
        if (musicAudioSource.clip == audioClip && musicAudioSource.isPlaying) return;

        musicAudioSource.clip = audioClip;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }

    public void PlayUi(UiSoundDataSo uiData)
    {
        AudioClip clip = uiData.buttonSounds[Random.Range(0, uiData.buttonSounds.Length)];
        uiAudioSource.PlayOneShot(clip);
    }

    public void PlaySfx(AudioClip[] sfxList)
    {
        AudioClip clip = sfxList[Random.Range(0, uiData.buttonSounds.Length)];
        sfxAudioSource.PlayOneShot(clip);
    }
}
