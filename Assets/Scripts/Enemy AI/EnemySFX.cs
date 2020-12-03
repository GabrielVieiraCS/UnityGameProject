using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFX : MonoBehaviour
{
    public AudioSource idleSFX;
    public AudioSource attackSFX;
    public AudioSource movementSFX;

    public void PlayidleSFX() {
        idleSFX.Play();
    }

    public void PlayattackSFX() {
        attackSFX.Play();
    }

    public void PlaymovementSFX() {
        movementSFX.Play();
    }

    
}
