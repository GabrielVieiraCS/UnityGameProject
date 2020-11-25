using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReportFunction : MonoBehaviour
{
    
    private GameObject[] players;
    private GameObject[] reportLocForPlayers;
    private Color[] colors;


    void Start()
    {
        players = GameObject.Find("GameDetails").GetComponent<GameDetails>().GetPlayers();
        reportLocForPlayers = new GameObject[players.Length];

        for(int i = 0; i < players.Length; i++){
            reportLocForPlayers[i] = GameObject.Find("Report"+i.ToString());
            
        }   

        //get rid of UI elements that will nt be used
        
        for(int i = (players.Length); i < 10; i++){
            GameObject.Find("Panel"+i.ToString()).SetActive(false);
        }
        
    }

    public void BodyReported(){

        GameObject.Find("Imposter Canvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Crewmate Canvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Report UI").GetComponent<Canvas>().enabled = true;

        for(int i = 0; i < players.Length; i++){
            players[i].transform.position = reportLocForPlayers[i].transform.position;

            players[i].GetComponent<Movement>().enabled = false;
            
        }

        GameObject[] bodies = GameObject.FindGameObjectsWithTag("DeadPlayer");

        foreach (GameObject body in bodies){
            body.SetActive(false);
        }

        SetupReportUI();

    }

    public void SetupReportUI(){
        Color[] playerColors = GameObject.Find("GameDetails").GetComponent<GameDetails>().GetColors();

        int alive = 0;
        for(int i = 0; i < players.Length; i++){
            //Set Player Name if Alive
            if(!players[i].GetComponent<Dead>().IsDead()){
                Text name = GameObject.Find("Name"+alive.ToString()).GetComponent<Text>();
                name.text = players[i].GetComponent<PlayerDetails>().name;
                //set Color
                name.color = playerColors[i];
                alive ++;
            }
        }

        int dead = 0;
        for(int i = 0; i < players.Length; i++){
            //Set Player Name if Dead
            if(players[i].GetComponent<Dead>().IsDead()){
                Text name = GameObject.Find("Name"+(alive + dead).ToString()).GetComponent<Text>();
                name.text = players[i].GetComponent<PlayerDetails>().name;

                //Disable their Vote button
                GameObject.Find("VoteButton"+(alive + dead).ToString()).GetComponent<Button>().enabled = false;

                //set Color
                name.color = playerColors[i];
                dead ++;
            }
        }

    }

    public void PersonVoted(int person){
        //do something
        
        GameObject.Find("Report UI").GetComponent<Canvas>().enabled = false;

        for(int i = 0; i < players.Length; i++){

            players[i].GetComponent<Movement>().enabled = true;

            if(players[i].GetComponent<Innocent>().CheckInnocent()){
                GameObject.Find("Crewmate Canvas").GetComponent<Canvas>().enabled = true;
            }else{
                GameObject.Find("Imposter Canvas").GetComponent<Canvas>().enabled = true;
                GameObject.Find("Crewmate Canvas").GetComponent<Canvas>().enabled = true;
            }
            
            
        }
    }
}
