using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    private Vector3 offset;

    private Space offsetSpace = Space.Self;

    private bool lookAt = true;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Refresh();
    }

    private void Refresh(){
        if(offsetSpace == Space.Self){
            transform.position = target.TransformPoint(offset);
        }else{
            transform.position = target.position + offset;
        }

        if(lookAt){
            transform.LookAt(target);
        }else{
            transform.rotation = target.rotation;
        }
    }
}
