using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenController : MonoBehaviour
{
    // script that controlls the events of what happens when you die
    public GameObject canvas;
    void Start(){

    } 

    public void PlayAgain(){
        SceneManager.LoadScene("Main Menu");

    }

    public void ExitGame(){
        Application.Quit();
        
    }

    void Update(){
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
