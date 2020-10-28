using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MPmovement : NetworkBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void OnStartLocalPlayer()
    {
        Movement script;
        script = GetComponent<Movement>();
        script.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
