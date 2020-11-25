using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDetails : MonoBehaviour
{
    private GameObject[] players;
    private GameObject[] impostors;
    private Color[] playerColors;

    void Awake(){
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    public GameObject[] GetPlayers(){
        return players;
    }

    public void SetImpostors(GameObject[] imp){
        impostors = imp;
    }

    public GameObject[] GetImpostors (){
        return impostors;
    }

    public void SetColors(Color[] col){
        playerColors = col;
    }

    public Color[] GetColors(){
        return playerColors;
    }
}
