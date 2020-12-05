using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent Enemy;
    public Transform player;
    static Animator anim;
    private PlayerInfo pInfo;
    private Movement playerRun;
    private EnemySFX soundFX;
    private bool aggro = false;
    private bool hasHit = false;
    System.Random rnd;
    public bool idleAudio = false;


    private Vector3[] positionArray = new Vector3[5];







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
        if (((Vector3.Distance(player.position, this.transform.position) < 25 && angle < 65 ) || (running && Vector3.Distance(player.position, this.transform.position) < 50)) && (!hiding))
        {
            aggro = true;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);
            if (direction.magnitude > 2 && (aggro))
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
                hasHit = true;
                if (hasHit) {
                    this.transform.position = RandomSpawnPoint();
                    hasHit = false;
                    aggro = false;
                }
            }
        }
        else if (Vector3.Distance(player.position, this.transform.position) > 65)
        {
            aggro = false;
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

    Vector3 RandomSpawnPoint() {
        positionArray[0] = new Vector3(14,0,40);
        positionArray[1] = new Vector3(59,0,23);
        positionArray[2] = new Vector3(77,0,-28);
        positionArray[3] = new Vector3(-24,0,-107);
        positionArray[4] = new Vector3(-74,0,-93);
        return positionArray[rnd.Next(0,4)];
    }
}
