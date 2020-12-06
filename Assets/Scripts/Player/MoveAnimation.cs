using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{

    // script to deal with the animations for the user

    Animator animPlayer;

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
        animPlayer.SetTrigger("walk");
        
    }

    public void StartRunning(){
        animPlayer.SetTrigger("run");
    }

    public void StopAnimation(){
        animPlayer.SetTrigger("stop");
    }

    public void StopRunning(){
        animPlayer.SetTrigger("stopRun");
    }

    public void Jump() {
        animPlayer.SetTrigger("jump");
    }

    public void StopJump() {
        animPlayer.SetTrigger("stopJump");
    }

    //This is no longer relavent - Old scripts use it so it is left in

    public void IsDead(){
        if(animPlayer == null){
            animPlayer = GetComponent<Animator>();
        }
        animPlayer.SetTrigger("dead");
    }

}
