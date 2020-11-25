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

    private bool flicker = true;

    System.Random rnd ;

    void Start()
    {
        normalLights = GameObject.FindGameObjectsWithTag("Light");
        morseLight = GameObject.Find("MorseSpotlight").GetComponent<Light>();
        rnd = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MorseFlicker());

        if(flicker){
            
            StartCoroutine(RandomFlicker());
            
        }
        
    }

    //get the light to flicker in morse
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
                    while (timePassed < length){
                        morseLight.enabled = false;
                        timePassed += Time.deltaTime;
                        yield return null; 
                    }

                }else{
                    while (timePassed < length){
                        morseLight.enabled = true;
                        timePassed += Time.deltaTime;
                        yield return null; 
                    }

                    if(charPause){
                        timePassed = 0f;
                        while (timePassed < unit){
                            morseLight.enabled = false;
                            timePassed += Time.deltaTime;
                            yield return null; 
                        }
                    }
                }


                
            }
            float timePassedSeq = 0f;
            while(timePassedSeq < unit * 10){
                morseLight.enabled = false;
                timePassedSeq += Time.deltaTime;
                yield return null; 
            }
        }
    }

    IEnumerator RandomFlicker(){
        flicker = false;
        int light = rnd.Next(normalLights.Length);
        int amount = rnd.Next(5);
        float timePassed = 0f;
        for(int i = 0; i < amount; i++){
            normalLights[light].GetComponent<Light>().enabled = !normalLights[light].GetComponent<Light>().enabled;
            while(timePassed < 0.2){
                timePassed += Time.deltaTime;
                yield return null; 
            }
        }
        
        normalLights[light].GetComponent<Light>().enabled = true;
        
        flicker = true;
    }
}
