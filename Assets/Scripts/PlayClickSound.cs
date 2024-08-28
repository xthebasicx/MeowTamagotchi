using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClickSound : MonoBehaviour
{
    private AudioManager audioManager;
    public void Start(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void PlayButtonSound()
    {
        audioManager.PlaySFX(audioManager.button);
    }
}
