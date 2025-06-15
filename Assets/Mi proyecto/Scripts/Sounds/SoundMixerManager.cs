using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public PlayerData playerData;

    public void SetSFXVolume()
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(playerData.VolumenSFX) * 20f);
    }

    public void SetMusicVolume()
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(playerData.VolumenMusica) * 20f);
    }

    void Update()
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(playerData.VolumenSFX) * 20f);
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(playerData.VolumenMusica) * 20f);
    }
}
