using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportFunction : MonoBehaviour
{
    
    private GameObject[] players;
    private GameObject[] reportLocForPlayers;


    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        reportLocForPlayers = new GameObject[players.Length];

        for(int i = 0; i < players.Length; i++){
            reportLocForPlayers[i] = GameObject.Find("Report"+i.ToString());
            
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
