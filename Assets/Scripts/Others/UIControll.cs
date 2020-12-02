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
    [Header("Glass Pannel Script")]
    public GlassPennel gp;
    
    void Start()
    {
        GameObject.Find("ObjectiveText").GetComponent<Text>().CrossFadeAlpha(0.8f, 0f, false);
        GameObject.Find("Door1Canvas").SetActive(false);
        GameObject glassPannel = GameObject.Find("GlassCanvas");
        SetupCanvasGlass(glassPannel);
        glassPannel.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void ActivateObjective(int objID){
        if(objID == 1){
            doorScript.ShowUI();
        }else if (objID == 2){
            hideScript.Hide();
        }else if (objID == 3){
            gp.ShowUI();
        }
    }


    private void SetupCanvasGlass(GameObject glassPannel){
        List<GameObject> buttons = new List<GameObject>();
        GameObject pannel = GameObject.Find("ButtonPanel1");
        for(int i = 0; i < 9; i ++){
            buttons.Add(GameObject.Find("GButton"+i.ToString()));
        }

        foreach (GameObject button in buttons)
        {
            button.GetComponent<RectTransform>().sizeDelta = new Vector2 (pannel.GetComponent<RectTransform>().sizeDelta.x / 3f, pannel.GetComponent<RectTransform>().sizeDelta.y / 3f);
        }
    }
}
