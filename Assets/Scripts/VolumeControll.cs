using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    public void setMusicVolume(){
        float musicVolume = musicVolumeSlider.value;
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume)*20);
    }
    public void setSfxVolume(){
        float sfxVolume = sfxVolumeSlider.value;
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(sfxVolume)*20);
    }
}
