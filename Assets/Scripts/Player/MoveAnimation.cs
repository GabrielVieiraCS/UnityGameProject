using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{

    Animator animPlayer;
    bool walking = false;

    // Start is called before the first frame update
    void Start()
    {
        animPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAnimation(){
        if(walking == false){
            animPlayer.SetTrigger("walk");
            walking = true;
        }
        
    }

    public void StopAnimation(){
        if(walking == true){
            animPlayer.SetTrigger("stop");
            walking = false;
        }
    }
}
