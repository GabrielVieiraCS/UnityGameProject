using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject playerHead;

    // controlls lights and sticks it as a flashlight or a soft light to bearly see the player
    void Update()
    {
        transform.position = playerHead.transform.position + new Vector3(0,1f,0);
        transform.rotation = playerHead.transform.rotation;
    }
}
