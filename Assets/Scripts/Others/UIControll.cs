using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControll : MonoBehaviour
{

    // this script deals with most of the ui events and trigering them

    [Header("Door1 Script")]
    public DoorOne doorScript;
    [Header("Lockers Script")]
    public HideLockers hideScript;
    [Header("Items Script")]
    public GameController gc;
    [Header("Glass Pannel Script")]
    public GlassPennel gp;
    [Header("One Two Three Pannel Script")]
    public OneTwoThreeTask oneTwoScript;
    [Header("Audio 1")]
    public AudioLog audioLogs;
    [Header("Audio Jakub")]
    public AudioLogsJakub audioLogsJakub;
    [Header("Audio Gabs")]
    public AudioLogsGabs audioLogsGabs;
    [Header("End Game")]
    public EndGameScript endGame;


    void Start()
    {
        GameObject.Find("ObjectiveText").GetComponent<Text>().CrossFadeAlpha(0.8f, 0f, false);
        GameObject.Find("Door1Canvas").SetActive(false);

        GameObject glassPannel = GameObject.Find("GlassCanvas");
        SetupCanvasGlass(glassPannel);
        glassPannel.SetActive(false);

        GameObject oneTwoPannel = GameObject.Find("OneTwoPanel");
        SetUpOneTwoThree(oneTwoPannel);
        GameObject.Find("OneTwoCanvas").SetActive(false);
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
        }else if(objID == 4){
            gc.CollectItem();
        }else if(objID == 5){
            oneTwoScript.ShowUI();
        }else if (objID == 6){
            audioLogs.PlayAudio();
        }else if(objID == 7){
            audioLogsJakub.PlayAudio();
        }else if(objID == 8){
            audioLogsGabs.PlayAudio();
        }else if(objID == 9){
            endGame.FinishGame();
        }
    }

    // set up this canvas based on the size of the users screen
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

    // set up this canvas based on the size of the users screen
    private void SetUpOneTwoThree(GameObject pannel){

        List<GameObject> buttons = new List<GameObject>();
        for(int i = 0; i < 10; i ++){
            buttons.Add(GameObject.Find("OneButton"+i.ToString()));
        }

        for(int i = 0; i < 5; i++){
            Vector3 prev = buttons[i].GetComponent<RectTransform>().anchoredPosition;
            Vector2 pannelSize = pannel.GetComponent<RectTransform>().sizeDelta;
            buttons[i].GetComponent<RectTransform>().sizeDelta = new Vector2((pannelSize.x / 5f), pannelSize.y /2f);
            buttons[i].GetComponent<RectTransform>().anchoredPosition = new Vector3((pannelSize.x / 5f)*i, prev.y, prev.z);
            buttons[i].GetComponentInChildren<Text>().fontSize =(int)(pannelSize.y / 3f);
        }

        int pos = 0;
        for(int i = 5; i < 10; i++){
            Vector3 prev = buttons[i].GetComponent<RectTransform>().anchoredPosition;
            Vector2 pannelSize = pannel.GetComponent<RectTransform>().sizeDelta;
            buttons[i].GetComponent<RectTransform>().sizeDelta = new Vector2((pannelSize.x / 5f), pannelSize.y /2f);
            buttons[i].GetComponent<RectTransform>().anchoredPosition = new Vector3((pannelSize.x / 5f)*pos, (prev.y - (pannelSize.y /2f)), prev.z);
            pos ++;
            buttons[i].GetComponentInChildren<Text>().fontSize =(int)(pannelSize.y / 3f);
        }
    }
}
