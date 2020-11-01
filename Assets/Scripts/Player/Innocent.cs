using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Innocent : MonoBehaviour
{
    public bool isInnocent = false;
    public bool isDummy;

    private GameObject[] players;
    private Text reportText;
    private Text useText;
    private bool reported = false;

    public void IsInnocent() {

        isInnocent = true;

        if (isDummy) { return; }
        players = GameObject.FindGameObjectsWithTag("Player");

        

        //find all UI Elements
        reportText = GameObject.Find("Report Text").GetComponent<Text>();
        useText = GameObject.Find("Use Text").GetComponent<Text>();

        //Set them to prefered opacity
        reportText.CrossFadeAlpha(0.3f, 0f, false);
        useText.CrossFadeAlpha(0.3f, 0f, false);

        //disable Impostor Elements
        GameObject.Find("Imposter Canvas").GetComponent<Canvas>().enabled = false;

    }

    
    void Update()
    {
        if (!isInnocent || isDummy) { return; }
        ClosestPersonDeadSearch();
    }

    public void ClosestPersonDeadSearch() {

        GameObject[] deadPlayers = GameObject.FindGameObjectsWithTag("DeadPlayer");
        GameObject closestDead = null;
        float distance = 0f;

        //find the nearenst dead player
        foreach (GameObject player in deadPlayers) {

            if (player.GetComponent<Dead>().IsDead())
            {

                if (closestDead == null){
                    closestDead = player;
                    distance = (transform.position - player.transform.position).magnitude;
                }
                else{

                    float tempDistance = (transform.position - player.transform.position).magnitude;
                    if (tempDistance < distance){
                        closestDead = player;
                        distance = tempDistance;
                    }
                }
            }
        }


        //Check if nearest dead body is reportable
        if (distance <= 3f && closestDead != null){
            reportText.CrossFadeAlpha(1, 0.0f, false);

            if (Input.GetKeyDown(KeyCode.R)){
                reported = true;
            }
        }
        else{
            reportText.CrossFadeAlpha(0.3f, 0f, false);
        }
    }

    void LateUpdate(){
        if(reported){
            GameObject.Find("Report Controller").GetComponent<ReportFunction>().BodyReported();
        }
    }


    public bool CheckInnocent() {
        return isInnocent;
    }
}
