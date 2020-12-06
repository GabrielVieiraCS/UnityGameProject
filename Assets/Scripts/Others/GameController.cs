using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    // this script deals with the items you need to pick up

    public Text itemText;
    public EndGameScript endGame;

    private GameObject[] items;
    private Text objectiveText;
    private bool isNear = false;
    private GameObject nearObject = null;
    private GameObject player;
    private Interaction interact;
    private int found = 0;


    void Start()
    {

        objectiveText = GameObject.Find("ObjectiveText").GetComponent<Text>();
        items = GameObject.FindGameObjectsWithTag("Item");
        player = GameObject.FindGameObjectWithTag("Player");
        interact = player.GetComponent<Interaction>();
        objectiveText.text = "Items Found [0/"+items.Length.ToString()+"]";

        string name = "Items Left: \n";
        foreach(GameObject item in items){
            name += item.name + "\n";
        }

        //set the side text
        itemText.text = name;
    }

    // Update is called once per frame
    void Update()
    {
        if(isNear){
            CheckIfLeft();
        }else{
            foreach(GameObject item in items){
                CheckIfNear(item);
            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void CheckIfNear(GameObject item){
        float distance = (item.transform.position - player.transform.position).magnitude;
        if(distance < 5f && item.activeInHierarchy){
            isNear = true;
            nearObject = item;
            interact.NearObjective(4);
        }
    }

    private void CheckIfLeft(){
        float distance = (nearObject.transform.position - player.transform.position).magnitude;
        if(distance > 4f){
            isNear = false;
            nearObject = null;
            interact.ObjectiveLeft();
        }
    }

    // what happens when you pick up an item
    public void CollectItem(){
        nearObject.SetActive(false);
        found ++;
        objectiveText.text = "Items Found ["+found.ToString()+"/"+items.Length.ToString()+"]";
        if(found == items.Length){
            ItemsCollected();
        }
        UpdateUI();
        interact.ObjectiveLeft();
    }

    // updatte the ui on the side of the screen
    public void UpdateUI(){
        string name = "Items Left: \n";
        foreach(GameObject item in items){
            if(item.activeSelf){name += item.name + "\n";}
        }

        itemText.text = name;
    }

    private void ItemsCollected(){
        //SceneManager.LoadScene("Game Won");
        endGame.ActivateObj();
        itemText.text = "All Items Found! \n Get to the engine room and \n Blow this place up!!!";
    }


}
