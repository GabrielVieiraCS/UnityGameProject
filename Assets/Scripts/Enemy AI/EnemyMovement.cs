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
    private Movement playerRun;
    private EnemySFX soundFX;
    //public float EnemyDistanceRun = 4.0f;

    System.Random rnd;
    public bool idleAudio = false;
    // Start is called before the first frame update
    void Start()
    {
        //Enemy = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        pInfo = player.GetComponent<PlayerInfo>();
        playerRun = player.GetComponent<Movement>();
        soundFX = GetComponent<EnemySFX>();

        rnd = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction,this.transform.forward);
        // Run towards Player

        bool hiding = pInfo.GetHidingStatus();
        bool running = playerRun.isRunning;
        if ((Vector3.Distance(player.position, this.transform.position) < 25 && angle < 65 && (!hiding)) || (running && Vector3.Distance(player.position, this.transform.position) < 50))
        {
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);
            if (direction.magnitude > 2)
            {
                this.transform.Translate(0,0,0.09f);
                anim.SetBool("isWalking",true);
                anim.SetBool("isAttacking",false);
                soundFX.PlaymovementSFX();
            }
            else
            {
                anim.SetBool("isAttacking",true);
                anim.SetBool("isWalking",false);
                pInfo.DamageTaken(25f);
                soundFX.PlayattackSFX();
            }
        }
        else
        {
            anim.SetBool("isIdle",true);
            anim.SetBool("isWalking",false);
            anim.SetBool("isAttacking",false);
            if(idleAudio == false){
                StartCoroutine(RandomidleNoise());
            }
            
        }
    }

    IEnumerator RandomidleNoise(){
        soundFX.PlayidleSFX();
        idleAudio = true;
        float delay = rnd.Next(40,100);
        float timePassed = 0f;
        while(timePassed < delay){
            timePassed += Time.deltaTime;
            yield return null; 
        }
        
        idleAudio = false;
    }
}
