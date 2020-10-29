using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    private bool isDead;
    public GameObject prefab;
    private GameObject selfPlayer;
    
    void start()
    {
        isDead = false;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players){
            //find the nearest player alive
            if ((transform.position - player.transform.position).magnitude == 0f){
                selfPlayer = player;
            }
        }
    }

    public void HasDied(){
        GameObject body = Instantiate(prefab, transform.position + new Vector3(0,0.2f,0), Quaternion.Euler(-90f,0,0));
        body.GetComponent<MoveAnimation>().IsDead();
        CharacterController cc = GetComponent<CharacterController>();
        cc.enabled = false;
        isDead = true;
        body.GetComponent<CharacterController>().enabled = false;
        gameObject.transform.GetChild(0).gameObject.layer = 1;
    }

    public bool IsDead(){
        return isDead; 
    }

    void Update(){

        if(isDead){
            //What to do when dead
        }

    }
}
