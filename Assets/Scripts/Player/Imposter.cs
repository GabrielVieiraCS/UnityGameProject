using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Imposter : MonoBehaviour
{

    public bool isImposter;
    private GameObject[] players;
    public Text killText;

    // Start is called before the first frame update
    void Start()
    {
        isImposter = true;
        players = GameObject.FindGameObjectsWithTag("Player");
        killText.CrossFadeAlpha(0.3f, 0f, false);
    }


    void FixedUpdate()
    {
        
        GameObject closest = null;
        float distance = 0;
        foreach (GameObject player in players)
        {
            if(!((transform.position - player.transform.position).magnitude == 0f) && !player.GetComponent<Dead>().IsDead()){
                if(closest == null){
                        closest = player;
                        distance = (transform.position - player.transform.position).magnitude;
                }else{

                    float tempDistance = (transform.position - player.transform.position).magnitude;
                    if(tempDistance < distance){
                        closest = player;
                        distance = tempDistance;
                    }

                }
            }
        }

        if(distance <= 3f){
            killText.CrossFadeAlpha(1, 0.0f, false);

            if(Input.GetKeyDown(KeyCode.Q)){
                closest.GetComponent<Dead>().HasDied();
            }

        }else{
            killText.CrossFadeAlpha(0.3f, 0f, false);
        }
    }
}
