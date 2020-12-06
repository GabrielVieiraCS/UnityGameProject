using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLockers : MonoBehaviour
{

    //script that deals with hiding in the lockers

    private GameObject player;
    private Interaction interact;
    private bool isNear = false;
    private bool isHiding = false;

    public GameObject worldLight;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        interact = player.GetComponent<Interaction>();
    }

    // Update is called once per frame
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
            interact.NearObjective(2);
        }
        
    }

    private void CheckLeft(){
        float distance = (transform.position - player.transform.position).magnitude;
        if(distance > 3f){
            isNear = false;
            interact.ObjectiveLeft();
        }
    }

    public void Hide(){
        if(isHiding){
            isHiding = false;
            player.GetComponent<PlayerInfo>().NotHiding();
            Transform child = player.transform.GetChild(0);
            child.GetComponent<SkinnedMeshRenderer> ().enabled = true;
            player.GetComponent<Movement>().enabled = true;
            worldLight.SetActive(false);
        }else{
            isHiding = true;
            player.GetComponent<PlayerInfo>().IsHiding();
            Transform child = player.transform.GetChild(0);
            child.GetComponent<SkinnedMeshRenderer> ().enabled = false;
            player.GetComponent<Movement>().enabled = false;
            worldLight.SetActive(true);
        }
    }

    public bool HidingStatus(){
        return isHiding;
    }
}
