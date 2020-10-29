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

        for(int i = 0; i < players.Length; i++){
            players[i].transform.position = reportLocForPlayers[i].transform.position;

            GameObject[] bodies = GameObject.FindGameObjectsWithTag("DeadPlayer");

            foreach (GameObject body in bodies){
                body.SetActive(false);
            }
            
        }

    }
}
