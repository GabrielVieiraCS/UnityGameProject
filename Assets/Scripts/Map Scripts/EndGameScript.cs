using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{
    // code that controlles the pannel in the engine room that allows you to win the game

    public Light lightToChange;

    private GameObject player;
    private Interaction interact;
    private bool isNear = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        interact = player.GetComponent<Interaction>();
    }

    
    void Update()
    {
        if(isNear){
            CheckLeft();
        }else{
            CheckIfNear();
        }
        

        
    }

    private void CheckIfNear(){
        
        float distance = (transform.position - player.transform.position).magnitude;
        if(distance < 3f){
            isNear = true;
            interact.NearObjective(9);
        }
        
    }

    private void CheckLeft(){
        float distance = (transform.position - player.transform.position).magnitude;
        if(distance > 3f){
            isNear = false;
            interact.ObjectiveLeft();
        }
    }

    public void ActivateObj(){
        lightToChange.color = Color.green;
    }

    public void FinishGame(){
        SceneManager.LoadScene("Game Won");
    }
}
