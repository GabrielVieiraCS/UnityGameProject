using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{

    private GameObject[] players;
    public GameObject[] impostors;
    System.Random rnd ;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        rnd = new System.Random();

        int noImpostors = NoOfImpostors();
        impostors = new GameObject[noImpostors];

        SetupImpostors(noImpostors);

        SetupPlayers();

        AssignColours();
    }


    //calculate howmany imposteres there needs to be
    private int NoOfImpostors() {

        if (players.Length <= 7){
            return 1;
        }
        else {
            return 2;
        }

    }

    private void SetupImpostors(int noImp) {

        for (int i = 0; i < noImp; i++){

            int pos = rnd.Next(players.Length);
            if (impostors.Contains(players[pos]))
            {

                int pos2 = rnd.Next(players.Length);
                while (pos == pos2) { pos2 = rnd.Next(players.Length); }

                impostors[i] = players[pos2];
            }
            else {
                impostors[i] = players[pos];
            }
        }

    }

    private void SetupPlayers() {

        foreach (GameObject player in players) {

            if (impostors.Contains(player)){
                player.GetComponent<Imposter>().IsImpostor();
            }
            else {
                player.GetComponent<Innocent>().IsInnocent();
            }
        
        }

    }

    private void AssignColours(){

        Material[] playerMaterials = GameObject.Find("Skin Controller").GetComponent<SkinController>().GetMaterials();
        Debug.Log(playerMaterials.Length);

        for(int i = 0; i < players.Length; i++){

            Transform child = players[i].transform.GetChild(0);
            int temPos = rnd.Next(playerMaterials.Length);
            child.GetComponent<SkinnedMeshRenderer>().material = playerMaterials[temPos];

            Material[] playerMaterialsTemp = new Material[playerMaterials.Length - 1];
            for(int j = 0; j < playerMaterials.Length; j++){
                if(j<temPos){playerMaterialsTemp[j] = playerMaterials[j];}
                else if(j>temPos){playerMaterialsTemp[j-1] = playerMaterials[j];}
            }
            playerMaterials = playerMaterialsTemp;
        }


    }
            
        
}
