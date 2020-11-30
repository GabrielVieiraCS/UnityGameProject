using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent Enemy;
    public Transform player;
    static Animator anim;
    private PlayerInfo pInfo;
    //public float EnemyDistanceRun = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        //Enemy = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        pInfo = player.GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction,this.transform.forward);
        // Run towards Player

        bool hiding = pInfo.GetHidingStatus();

        if (Vector3.Distance(player.position, this.transform.position) < 10 && angle < 65 && (!hiding) )
        {
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);
            if (direction.magnitude > 2)
            {
                this.transform.Translate(0,0,0.09f);
                anim.SetBool("isWalking",true);
                anim.SetBool("isAttacking",false);
                pInfo.DamageTaken(15f);
            }
            else
            {
                anim.SetBool("isAttacking",true);
                anim.SetBool("isWalking",false);
                pInfo.DamageTaken(25f);
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
