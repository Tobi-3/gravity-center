using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    [Header("Audios")]
    [SerializeField] private AudioSource src;
    [SerializeField] private AudioClip idleMusic, menuMusic;

    // Update is called once per frame
    void Update()
    {
        inGame();
    }

    private void inGame(){
        src.clip = idleMusic;
        if(!src.isPlaying){            
            src.Play();
        }
    }
}
