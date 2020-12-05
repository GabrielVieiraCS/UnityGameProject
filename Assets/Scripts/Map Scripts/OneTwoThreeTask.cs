using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneTwoThreeTask : MonoBehaviour
{
    [Header("Glass Pannel UI")]
    public GameObject taskCanvas;
    [Header("Glass Pannels")]
    public GameObject glassPennel1;
    public GameObject glassPennel2;
    public GameObject gpannel;
    
    private GameObject player;
    private Interaction interact;
    private bool isNear = false;
    private List<GameObject> buttons;
    private int noOn = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        interact = player.GetComponent<Interaction>();

        buttons = new List<GameObject>();
        for(int i = 0; i < 10; i ++){
            buttons.Add(GameObject.Find("OneButton"+i.ToString()));
        }

        List<int> numbers = new List<int>(){0,1,2,3,4,5,6,7,8,9};
        numbers = Shuffle(numbers);
        

        System.Random rnd = new System.Random();
        for(int i = 0; i < 10; i ++){
            buttons[i].GetComponent<Image>().color = new Color(124f/255f, 10f/255f, 2f/255);
            buttons[i].GetComponentInChildren<Text>().text = numbers[i].ToString();
        }

    }

    
    void Update()
    {
        if(isNear){
            CheckLeft();
        }else{
            CheckIfNear();
        }
        
    }

    private void CheckIfNear(){
        
        float distance = (transform.position - player.transform.position).magnitude;
        if(distance < 3f){
            isNear = true;
            interact.NearObjective(5);
        }
        
    }

    private void CheckLeft(){
        float distance = (transform.position - player.transform.position).magnitude;
        if(distance > 3f){
            isNear = false;
            interact.ObjectiveLeft();
        }
    }

    public void ShowUI(){
        taskCanvas.SetActive(true);
        player.GetComponent<Movement>().enabled = false;
    }

    public void ButtonPressed(int id){
        if(System.Int32.Parse(buttons[id].GetComponentInChildren<Text>().text) == noOn){
            FlipColour(id);
            noOn ++;
        }else{
            foreach(GameObject button in buttons){
                button.GetComponent<Image>().color = new Color(124f/255f, 10f/255f, 2f/255);
                noOn = 0;
            }
        }
        
        CheckIfWon();
    }

    private void FlipColour(int id){
        if(buttons[id].GetComponent<Image>().color == new Color(124f/255f, 10f/255f, 2f/255)){
            buttons[id].GetComponent<Image>().color = new Color(7f/255f, 136f/255f, 70f/255f);
        }else{
            buttons[id].GetComponent<Image>().color = Color.red;
        }
    }

    private void CheckIfWon(){
        bool won = true;
        foreach (GameObject button in buttons){
            if(button.GetComponent<Image>().color == new Color(124f/255f, 10f/255f, 2f/255)){
                won = false;
                break;
            }
        }

        if(won){
            glassPennel1.SetActive(false);
            glassPennel2.SetActive(false);
            ExitScreen();
            interact.ObjectiveLeft();
            gpannel.SetActive(false);
        }
    }

    public void ExitScreen(){
        taskCanvas.SetActive(false);
        player.GetComponent<Movement>().enabled = true;
    }

    private List<int> Shuffle(List<int> list){  
        System.Random rng = new System.Random();
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            int value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
        return list;
    }
}
