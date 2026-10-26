using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UiSettingsMenu : MonoBehaviour
{
    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("Volume Sliders")]
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderBackground;
    [SerializeField] private Slider sliderSfx;
    [SerializeField] private Slider sliderUi;

    private void Awake()
    {
        sliderMaster.onValueChanged.AddListener(OnVolumeMasterChanged);
        sliderBackground.onValueChanged.AddListener(OnVolumeBackgroundChanged);
        sliderSfx.onValueChanged.AddListener(OnVolumeSfxChanged);
        sliderUi.onValueChanged.AddListener(OnVolumeUiChanged);
    }

    private void Start()
    {
        float volume = 0f;
        const float volumeConstant = 80f;

        audioMixer.GetFloat("VolumeMaster", out volume);
        sliderMaster.value = volume + volumeConstant;

        audioMixer.GetFloat("VolumeBackground", out volume);
        sliderBackground.value = volume + volumeConstant;
        
        audioMixer.GetFloat("VolumeSfx", out volume);
        sliderSfx.value = volume + volumeConstant;
        
        audioMixer.GetFloat("VolumeUi", out volume);
        sliderUi.value = volume + volumeConstant;

    }

    private void OnDestroy()
    {
        sliderMaster.onValueChanged.RemoveAllListeners();
        sliderBackground.onValueChanged.RemoveAllListeners();
        sliderSfx.onValueChanged.RemoveAllListeners();
        sliderUi.onValueChanged.RemoveAllListeners();
    }

    // Eventos de las sliders
    private void OnVolumeMasterChanged(float value)
    {
        ModifyMixerVolume("VolumeMaster", value);
    }

    private void OnVolumeBackgroundChanged(float value)
    {
        ModifyMixerVolume("VolumeBackground", value);
    }

    private void OnVolumeSfxChanged(float value)
    {
        ModifyMixerVolume("VolumeSfx", value);
    }

    private void OnVolumeUiChanged(float value)
    {
        ModifyMixerVolume("VolumeUi", value);
    }

    // Funcion para transformar el valor de las sliders (lineal), a un valor lo más cercano al del mixer (decibelios)
    private void ModifyMixerVolume(string volumeVariableName, float volumeValue)
    {
        float finalVolume = Mathf.Clamp(Mathf.Log10(volumeValue) * 50f, -80f, 0); // Se limita entre estos valores para que no se vaya a -infinito
        audioMixer.SetFloat(volumeVariableName, finalVolume);
    }
}
