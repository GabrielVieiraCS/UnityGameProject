using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{

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

    public void StopAnimation(){
        animPlayer.SetTrigger("stop");
    }

    public void Jump() {
        animPlayer.SetTrigger("jump");
    }

    public void StopJump() {
        animPlayer.SetTrigger("stopJump");
    }

    public void IsDead(){
        animPlayer.SetTrigger("dead");
    }

}
