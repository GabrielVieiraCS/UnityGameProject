using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonHandler : MonoBehaviour
{
    void Start(){

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
