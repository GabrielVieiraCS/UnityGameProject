using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent Enemy;
    public Transform Player;
    static Animator anim;
    //public float EnemyDistanceRun = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        //Enemy = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.position - this.transform.position;
        float angle = Vector3.Angle(direction,this.transform.forward);
        // Run towards Player

        if (Vector3.Distance(Player.position, this.transform.position) < 10 && angle < 65)
        {
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);
            if (direction.magnitude > 2)
            {
                this.transform.Translate(0,0,0.09f);
                anim.SetBool("isWalking",true);
                anim.SetBool("isAttacking",false);
            }
            else
            {
                anim.SetBool("isAttacking",true);
                anim.SetBool("isWalking",false);
            }
        }
        else
        {
            anim.SetBool("isIdle",true);
            anim.SetBool("isWalking",false);
            anim.SetBool("isAttacking",false);
        }
    }
}
