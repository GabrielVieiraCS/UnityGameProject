using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenController : MonoBehaviour
{
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
