using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControll : MonoBehaviour
{

    [Header("Door1 Script")]
    public DoorOne doorScript;
    [Header("Lockers Script")]
    public HideLockers hideScript;
    [Header("Items Script")]
    public GameController gc;
    
    void Start()
    {
        GameObject.Find("ObjectiveText").GetComponent<Text>().CrossFadeAlpha(0.8f, 0f, false);
        GameObject.Find("Door1Canvas").SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void ActivateObjective(int objID){
        if(objID == 1){
            doorScript.ShowUI();
        }else if (objID == 2){
            hideScript.Hide();
        }
    }
}
