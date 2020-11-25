using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [Header("Use Text")]
    public Text useText;

    private int nearID = 0; // ) means no Obj near
    
    
    void Start()
    {
        useText.CrossFadeAlpha(0.3f, 0f, false);
    }

    
    void Update()
    {
        
    }

    public void NearObjective(int objID){
        nearID = objID;
        
    }
}
