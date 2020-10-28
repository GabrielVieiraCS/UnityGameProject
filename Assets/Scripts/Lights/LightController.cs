using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject playerHead;

    // Update is called once per frame
    void Update()
    {
        transform.position = playerHead.transform.position + new Vector3(0,1f,0);
        transform.rotation = playerHead.transform.rotation;
    }
}
