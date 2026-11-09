using UnityEngine;

[CreateAssetMenu(fileName = "AudioSettingsData", menuName = "Data/Audio/AudioSettingsData")]

public class AudioSettingsDataSo : ScriptableObject
{
    [Range(1, 100)] public float volumeMaster = 50.0f;
    [Range(1, 100)] public float volumeMusic = 50.0f;
    [Range(1, 100)] public float volumeSfx = 50.0f;
    [Range(1, 100)] public float volumeUi = 50.0f;
}
