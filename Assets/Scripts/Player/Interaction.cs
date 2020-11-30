using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [Header("UI Controller")]
    public UIControll uiController;
    [Header("Use Text")]
    public Text useText;

    
    
    private int objID = 0; // 0 means no Obj near
    
    void Start()
    {
        useText.CrossFadeAlpha(0.3f, 0f, false);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && objID > 0){
            uiController.ActivateObjective(objID);
        }
    }

    public void NearObjective(int objID){
        this.objID = objID;
        useText.CrossFadeAlpha(1, 0f, false);
    }

    public void ObjectiveLeft(){
        this.objID = 0;
        useText.CrossFadeAlpha(0.3f, 0f, false);
    }
}
