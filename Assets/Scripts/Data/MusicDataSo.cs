using UnityEngine;

[CreateAssetMenu(fileName = "MusicData", menuName = "Data/Audio/MusicData")]

public class MusicDataSo : ScriptableObject
{
    public AudioClip mainMenuMusic;
    public AudioClip gameplayMusic;
}
