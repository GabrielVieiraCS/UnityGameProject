using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Dead : NetworkBehaviour
{
    private bool isDead;
    public MoveAnimation moveAnimation;
    
    void start()
    {
        isDead = false;
    }

    public void HasDied(){
        moveAnimation.IsDead();
        transform.rotation = Quaternion.Euler(-90f,0,0);
        transform.position = transform.position + new Vector3(0,0.2f,0);
        CharacterController cc = GetComponent<CharacterController>();
        cc.enabled = false;
        isDead = true;
    }

    public bool IsDead(){
        return isDead; 
    }
}
