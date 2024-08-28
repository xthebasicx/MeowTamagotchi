using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource VoiceSource;
    public AudioClip bgm;
    public AudioClip button;
    public AudioClip jojocat;
    public AudioClip oiiacat;
    public AudioClip musclecat;
    public AudioClip happycat;
    public AudioClip huhcat;
    public AudioClip sadcat;
    public AudioClip sleep;
    public AudioClip eat;

    private static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        BGMSource.clip = bgm;
        BGMSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayVoice(AudioClip clip)
    {
        VoiceSource.PlayOneShot(clip);
    }
}
