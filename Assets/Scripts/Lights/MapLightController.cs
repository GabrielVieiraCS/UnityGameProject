using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLightController : MonoBehaviour
{

    [Header("Time unit:")]
    public float unit;
    
    private GameObject[] normalLights;
    private GameObject morseLight;
    private string morsePattern = ".- .--- --.";

    void Start()
    {
        normalLights = GameObject.FindGameObjectsWithTag("Light");
        morseLight = GameObject.Find("MorseSpotlight");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
