using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFX : MonoBehaviour
{
    public AudioClip idleSFX;
    public AudioClip attackSFX;
    public AudioClip movementSFX;
    public AudioSource source;

    public void PlayidleSFX() {
        if(source.isPlaying == false){
            source.PlayOneShot(idleSFX);
        }
        
    }

    public void PlayattackSFX() {
        if(source.isPlaying == false){source.PlayOneShot(attackSFX);}
        
        
    }

    public void PlaymovementSFX() {
        source.PlayOneShot(movementSFX);
        
    }

    
}
