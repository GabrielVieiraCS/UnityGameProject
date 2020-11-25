using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOne : MonoBehaviour
{

    [Header("DoorUI")]
    public GameObject password;
    private string accPass = "ajg"; 
    
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
            interact.NearObjective(1);
        }
        
    }

    private void CheckLeft(){
        float distance = (transform.position - player.transform.position).magnitude;
        if(distance > 3f){
            isNear = false;
            interact.ObjectiveLeft();
        }
    }

    public void ShowUI(){
        password.SetActive(true);
        player.GetComponent<Movement>().enabled = false;
    }

    public void PasswordEntered(){
        string userAns = GameObject.Find("Door1Text").GetComponent<Text>().text;
        if (userAns == accPass){
            GameObject.Find("Door1").SetActive(false);
            ExitScreen();
        }
    }

    public void ExitScreen(){
        password.SetActive(false);
        player.GetComponent<Movement>().enabled = true;
    }
}
