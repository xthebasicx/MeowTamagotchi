using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider MasterSlider;
    public Slider BGMSlider;
    public Slider SFXSlider;
    public Slider VoiceSlider;

    public void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetBGMVolume();
            SetBGMVolume();
            SetSFXVolume();
            SetVoiceVolume();
        }
    }
    public void SetMasterVolume()
    {
        float volume = MasterSlider.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
    public void SetBGMVolume()
    {
        float volume = BGMSlider.value;
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    public void SetVoiceVolume()
    {
        float volume = VoiceSlider.value;
        audioMixer.SetFloat("Voice", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("VoiceVolume", volume);
    }
    private void LoadVolume()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        VoiceSlider.value = PlayerPrefs.GetFloat("VoiceVolume");
    }
}
