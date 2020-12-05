using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    public Text itemText;

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

    public void CollectItem(){
        nearObject.SetActive(false);
        found ++;
        objectiveText.text = "Items Found ["+found.ToString()+"/"+items.Length.ToString()+"]";
        if(found == items.Length){
            GameWon();
        }
        UpdateUI();
        interact.ObjectiveLeft();
    }

    public void UpdateUI(){
        string name = "Items Left: \n";
        foreach(GameObject item in items){
            if(item.activeSelf){name += item.name + "\n";}
        }

        itemText.text = name;
    }

    private void GameWon(){
        SceneManager.LoadScene("Game Won");
    }


}
