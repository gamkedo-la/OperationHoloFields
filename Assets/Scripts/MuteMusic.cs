using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteMusic : MonoBehaviour
{

    AudioSource audioSource;
    
    
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleMusicMute(){
        audioSource.mute = !audioSource.mute;
    }
}
