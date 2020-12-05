using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject rulesCanvas;

    void Start(){
        rulesCanvas.SetActive(false);
    }
    
    void Update(){
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void DisplayRules(){
        rulesCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }

    public void StartGame(){
        SceneManager.LoadScene("MainLevel");
    }
}
