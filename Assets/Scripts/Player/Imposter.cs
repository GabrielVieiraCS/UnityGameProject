using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Imposter : NetworkBehaviour
{

    public bool isImposter;
    private GameObject[] players;

    private Text killText;
    private Text reportText;
    private Text sabotageText;
    private Text useText;

    // Start is called before the first frame update
    void Start()
    {
        isImposter = true;
        players = GameObject.FindGameObjectsWithTag("Player");

        //find all UI Elements
        killText = GameObject.Find("Kill Text").GetComponent<Text>();
        reportText = GameObject.Find("Report Text").GetComponent<Text>();
        sabotageText = GameObject.Find("Sabotage Text").GetComponent<Text>();
        useText = GameObject.Find("Use Text").GetComponent<Text>();

        //Set them to prefered opacity
        killText.CrossFadeAlpha(0.3f, 0f, false);
        reportText.CrossFadeAlpha(0.3f, 0f, false);
        sabotageText.CrossFadeAlpha(0.3f, 0f, false);
        useText.CrossFadeAlpha(0.3f, 0f, false);


    }


    void FixedUpdate()
    {

        ClosestPersonDeadAndAliveSearch();

    }


    public void ClosestPersonDeadAndAliveSearch() {

        GameObject closest = null;
        float distance = 0;

        GameObject closestDead = null;
        float distanceDead = 0f;
        foreach (GameObject player in players){
            //find the nearest player alive
            if (!((transform.position - player.transform.position).magnitude == 0f) && !player.GetComponent<Dead>().IsDead()){
                if (closest == null){
                    closest = player;
                    distance = (transform.position - player.transform.position).magnitude;
                }
                else{

                    float tempDistance = (transform.position - player.transform.position).magnitude;
                    if (tempDistance < distance){
                        closest = player;
                        distance = tempDistance;
                    }

                }
            }

            //find the nearenst dead player
            if (player.GetComponent<Dead>().IsDead()){

                if (closestDead == null){
                    closestDead = player;
                    distanceDead = (transform.position - player.transform.position).magnitude;
                }
                else{

                    float tempDistance = (transform.position - player.transform.position).magnitude;
                    if (tempDistance < distanceDead){
                        closestDead = player;
                        distanceDead = tempDistance;
                    }

                }

            }
        }

        //check to see if the nearest player alive is killable
        if (distance <= 3f && closest != null){
            killText.CrossFadeAlpha(1, 0.0f, false);

            if (Input.GetKeyDown(KeyCode.Q)){
                closest.GetComponent<Dead>().HasDied();
            }

        }
        else{
            killText.CrossFadeAlpha(0.3f, 0f, false);
        }

        //check to see if the nearest player dead is reportable

        if (distanceDead <= 3f && closestDead != null){
            reportText.CrossFadeAlpha(1, 0.0f, false);

            if (Input.GetKeyDown(KeyCode.R))
            {
                //what to do when reported
            }
        }
        else{
            reportText.CrossFadeAlpha(0.3f, 0f, false);
        }

    }
}
