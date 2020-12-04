using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLog : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource log;
    private GameObject player;
    private Interaction interact;
    private bool isNear = false;
    private bool done = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        interact = player.GetComponent<Interaction>();
    }

    
    void Update()
    {
        if(!done){
            if(isNear){
                CheckLeft();
            }else{
                CheckIfNear();
            }
        }
    }

    private void CheckIfNear(){
        
        float distance = (transform.position - player.transform.position).magnitude;
        if(distance < 3f){
            isNear = true;
            interact.NearObjective(6);
        }
        
    }

    private void CheckLeft(){
        float distance = (transform.position - player.transform.position).magnitude;
        if(distance > 3f){
            isNear = false;
            interact.ObjectiveLeft();
        }
    }

    public void PlayAudio(){
        done = true;
        if(log.isPlaying == false){log.Play();}
        interact.ObjectiveLeft();
    }

    
}
