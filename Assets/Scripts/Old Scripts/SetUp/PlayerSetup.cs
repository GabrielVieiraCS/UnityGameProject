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
        players = GameObject.Find("GameDetails").GetComponent<GameDetails>().GetPlayers();
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

        GameObject.Find("GameDetails").GetComponent<GameDetails>().SetImpostors(impostors);

    }

    private void SetupPlayers() {

        GameObject.Find("Report UI").GetComponent<Canvas>().enabled = false;

        foreach (GameObject player in players) {

            if (impostors.Contains(player)){
                player.GetComponent<Imposter>().IsImpostor();
            }
            else {
                player.GetComponent<Innocent>().IsInnocent();
            }

            player.GetComponent<PlayerDetails>().name = "Player"+rnd.Next(100).ToString();
        
        }

    }

    private void AssignColours(){

        Material[] playerMaterials = GameObject.Find("Skin Controller").GetComponent<SkinController>().GetMaterials();
        Color[] possiblePlayerColors = GameObject.Find("Skin Controller").GetComponent<SkinController>().GetColors();
        Color[] playerColors = new Color[players.Length];

        for(int i = 0; i < players.Length; i++){
            //set and record what color the player is
            Transform child = players[i].transform.GetChild(0);
            int temPos = rnd.Next(playerMaterials.Length);
            child.GetComponent<SkinnedMeshRenderer>().material = playerMaterials[temPos];
            playerColors[i] = possiblePlayerColors[temPos];

            //take that material out of the choices available
            Material[] playerMaterialsTemp = new Material[playerMaterials.Length - 1];
            for(int j = 0; j < playerMaterials.Length; j++){
                if(j<temPos){playerMaterialsTemp[j] = playerMaterials[j];}
                else if(j>temPos){playerMaterialsTemp[j-1] = playerMaterials[j];}
            }
            //tale that color out of that choices avalable
            Color[] playerColorTemp = new Color[possiblePlayerColors.Length - 1];
            for(int j = 0; j < possiblePlayerColors.Length; j++){
                if(j<temPos){playerColorTemp[j] = possiblePlayerColors[j];}
                else if(j>temPos){playerColorTemp[j-1] = possiblePlayerColors[j];}
            }

            playerMaterials = playerMaterialsTemp;
            possiblePlayerColors = playerColorTemp;
        }

        
        GameObject.Find("GameDetails").GetComponent<GameDetails>().SetColors(playerColors);

    }
            
        
}
