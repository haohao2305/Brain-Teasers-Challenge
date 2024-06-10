using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;
    [SerializeField] private AudioSource Music;
    [SerializeField] private AudioSource SoundEffect;
    [SerializeField] private AudioClip dungSE, saiSE;
    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Singleton>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void VolumeAudioSource()
    {
        Music.volume = PlayerPrefs.GetInt("music");
        SoundEffect.volume = PlayerPrefs.GetInt("soundEffect");
    }
    public void PlayDungSoundEffect()
    {
        SoundEffect.PlayOneShot(dungSE);
    }
    public void PlaySaiSoundEffect()
    {
        SoundEffect.PlayOneShot(saiSE);
    }
}
