using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLightController : MonoBehaviour
{

    [Header("Time unit:")]
    public float unit;
    
    private GameObject[] normalLights;
    private Light morseLight;
    private string morsePattern = ".- .--- --.";

    void Start()
    {
        normalLights = GameObject.FindGameObjectsWithTag("Light");
        morseLight = GameObject.Find("MorseSpotlight").GetComponent<Light>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(MorseFlicker());
        
    }

    IEnumerator MorseFlicker(){
        while(true){
            for(int i = 0; i < morsePattern.Length; i++){
                bool charPause = true;
                float length = 0f;
                if(morsePattern[i] == '.'){
                    length = unit * 1f;
                }else if (morsePattern[i] == '-'){
                    length = unit * 3f;
                } 

                if ((i + 1) < morsePattern.Length){
                    if(morsePattern[i+1] == ' '){
                        charPause = false;
                    }
                }

                float timePassed = 0f;
                if (morsePattern[i] == ' '){
                    length = unit * 7f;
                    // morseLight.enabled = false;
                    // yield return new WaitForSeconds(length);
                    while (timePassed < length){
                        morseLight.enabled = false;
                        timePassed += Time.deltaTime;
                        yield return null; 
                    }

                }else{
                    // morseLight.enabled = true;
                    // yield return new WaitForSeconds(length);
                    while (timePassed < length){
                        morseLight.enabled = true;
                        timePassed += Time.deltaTime;
                        yield return null; 
                    }

                    if(charPause){
                        timePassed = 0f;
                        // morseLight.enabled = false;
                        // yield return new WaitForSeconds(length);
                        while (timePassed < unit){
                            morseLight.enabled = false;
                            timePassed += Time.deltaTime;
                            yield return null; 
                        }
                    }
                }


                
            }
            float timePassedSeq = 0f;
            // morseLight.enabled = false;
            // yield return new WaitForSeconds(unit * 10);
            while(timePassedSeq < unit * 10){
                morseLight.enabled = false;
                timePassedSeq += Time.deltaTime;
                yield return null; 
            }
        }
    }
}
