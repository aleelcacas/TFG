using Unity.Mathematics;
using UnityEditor.Search;
using UnityEngine;

public class SFX_Manager : MonoBehaviour
{
    public static SFX_Manager instance;
    public AudioSource sfxObject;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PlaySFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(sfxObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLenght = audioSource.clip.length;
        Destroy(audioSource, clipLenght);
    }
}
