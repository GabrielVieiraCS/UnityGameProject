using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent Enemy;
    public Transform player;
    public ParticleSystem Explosion;
    static Animator anim;
    private PlayerInfo pInfo;
    private Movement playerRun;
    private EnemySFX soundFX;
    public bool aggro = false;
    public bool hasHit = false;
    System.Random rnd;
    public bool idleAudio = false;

    public MovementPattern mp;


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
        Explosion.Stop();
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction,this.transform.forward);
        // Run towards Player

        bool hiding = pInfo.GetHidingStatus();
        bool running = playerRun.isRunning;
        if (((Vector3.Distance(player.position, this.transform.position) < 25 && angle < 65 ) || (running && Vector3.Distance(player.position, this.transform.position) < 50)) && (!hiding))
        {
            aggro = true;
            direction.y = 0;

            mp.enabled = false;

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
                pInfo.DamageTaken(rnd.Next(15,25));
                soundFX.PlayattackSFX();
                hasHit = true;
                if (hasHit) {
                    Explosion.transform.position = player.transform.position;
                    Explosion.Play();
                    mp.enabled = true;
                    mp.RestartPattern();
                    hasHit = false;
                    aggro = false;
                }
            }
        }
        else if (Vector3.Distance(player.position, this.transform.position) > 65)
        {
            aggro = false;
            if(!mp.onPath){
                anim.SetBool("isIdle",true);
                anim.SetBool("isWalking",false);
                anim.SetBool("isAttacking",false);
            }
            if(idleAudio == false){
                StartCoroutine(RandomidleNoise());
            }
            if(mp.enabled == false){
                mp.enabled = true;
            }
            
        }else if(((Vector3.Distance(player.position, this.transform.position) < 25 && angle < 65 ) || (running && Vector3.Distance(player.position, this.transform.position) < 50)) && hiding){
            aggro = false;
            Explosion.transform.position = player.transform.position;
            Explosion.Play();
            mp.enabled = true;
            mp.RestartPattern();
        }else{
            if(mp.enabled == false){
                mp.enabled = true;
            }
        }
    }

    IEnumerator RandomidleNoise(){
        soundFX.PlayidleSFX();
        idleAudio = true;
        float delay = rnd.Next(10,50);
        float timePassed = 0f;
        while(timePassed < delay){
            timePassed += Time.deltaTime;
            yield return null; 
        }
        
        idleAudio = false;
    }

    
}
