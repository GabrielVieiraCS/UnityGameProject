using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
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
    }

    private void CheckIfNear(GameObject item){
        float distance = (item.transform.position - player.transform.position).magnitude;
        if(distance < 3f && item.activeInHierarchy){
            isNear = true;
            nearObject = item;
            interact.NearObjective(4);
        }
    }

    private void CheckIfLeft(){
        float distance = (nearObject.transform.position - player.transform.position).magnitude;
        if(distance > 3f){
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
        interact.ObjectiveLeft();
    }

    private void GameWon(){
        //What to do when game won
    }


}
