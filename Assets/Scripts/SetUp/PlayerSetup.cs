using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{

    private GameObject[] players;
    public GameObject[] impostors;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        int noImpostors = NoOfImpostors();
        impostors = new GameObject[noImpostors];

        SetupImpostors(noImpostors);

        SetupPlayers();
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

        System.Random rnd = new System.Random();

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
            
        
}
