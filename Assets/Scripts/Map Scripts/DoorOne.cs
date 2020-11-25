using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOne : MonoBehaviour
{
    
    private GameObject player;
    private Interaction interact;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        interact = player.GetComponent<Interaction>();
    }

    
    void Update()
    {
        
    }

    private void CheckIfNear(){
        float distance = (transform.position - player.transform.position).magnitude;
        if(distance < 3f){
            interact.NearObjective(1);
        }
    }
}
