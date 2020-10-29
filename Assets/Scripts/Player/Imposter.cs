using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Imposter : MonoBehaviour
{

    public bool isImposter = false;
    public bool isDummy;
    private GameObject[] players;

    private Text killText;
    private Text reportText;
    private Text sabotageText;
    private Text useText;


    void Update()
    {
        if (!isImposter || isDummy) { return; }
        ClosestPersonDeadAndAliveSearch();

    }

    public void IsImpostor() {

        isImposter = true;

        if (isDummy) { return; }

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
                Debug.Log("ASDFASDFASDFASDf");
            }
        }
        else{
            reportText.CrossFadeAlpha(0.3f, 0f, false);
        }

    }

    public bool CheckImpostor() {
        return isImposter;
    }
}
