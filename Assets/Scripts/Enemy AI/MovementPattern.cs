using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPattern : MonoBehaviour
{
    public EnemyAI aiScript;
    public GameObject monster;
    public GameObject player;
    static Animator anim;

    private List<GameObject> storagePath;
    private List<GameObject> gymPath;
    private List<GameObject> wepPath;
    private List<GameObject> engPath;
    private List<GameObject> dormPath;
    private List<GameObject> cafPath;
    private List<GameObject> medPath;
    private bool waiting = false;
    private bool started = false;

    private List<GameObject> currentPath;
    private int pos = 0;
    public bool onPath = false;

    System.Random rnd;

    //At the start, get all the locations of all the routes throughout the map
    void Start()
    {
        anim = GetComponent<Animator>();
        rnd = new System.Random();

        storagePath = new List<GameObject>();
        for(int i = 0; i < 10; i ++){
            storagePath.Add(GameObject.Find("Stor"+i.ToString()));
        }

        gymPath = new List<GameObject>();
        for(int i = 0; i < 10; i ++){
            gymPath.Add(GameObject.Find("Gym ("+i.ToString()+")"));
        }

        wepPath = new List<GameObject>();
        for(int i = 0; i < 9; i ++){
            wepPath.Add(GameObject.Find("Wep ("+i.ToString()+")"));
        }

        engPath = new List<GameObject>();
        for(int i = 0; i < 9; i ++){
            engPath.Add(GameObject.Find("Eng ("+i.ToString()+")"));
        }

        dormPath = new List<GameObject>();
        for(int i = 0; i < 10; i ++){
            dormPath.Add(GameObject.Find("Dorm ("+i.ToString()+")"));
        }

        cafPath = new List<GameObject>();
        for(int i = 0; i < 9; i ++){
            cafPath.Add(GameObject.Find("Caf ("+i.ToString()+")"));
        }

        medPath = new List<GameObject>();
        for(int i = 0; i < 16; i ++){
            medPath.Add(GameObject.Find("Med ("+i.ToString()+")"));
        }

        currentPath = storagePath;

    }

    // Update is called once per frame
    //
    //get the monster to walk through a route
    void Update()
    {
        //if finished a route, move to a room close to the player
        if(pos == currentPath.Count){
            MoveToClosestRoom();
        }

        if(!(currentPath[pos].transform.position == monster.transform.position) && pos == 0){
            monster.GetComponent<Transform>().position = currentPath[0].GetComponent<Transform>().position;
        }

        Vector3 direction =  currentPath[pos].transform.position - monster.transform.position ;
        if(!(direction == new Vector3(0f,0f,0f))){
            monster.transform.rotation = Quaternion.Slerp(monster.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
        }
        float delta = 5f * Time.deltaTime ;
        monster.transform.position = Vector3.MoveTowards(monster.transform.position, currentPath[pos].GetComponent<Transform>().position, delta);
        anim.SetBool("isWalking",true);

        if(currentPath[pos].transform.position == monster.transform.position && !waiting){
            pos ++;
            onPath = true;
            waiting = true;

            //there is a 5% chance that the enemy will teleport to a random different room when walking a route
            int num = rnd.Next(1,101);
            if ((num % 20) == 0){
                RestartPattern();
            }
        }else if(currentPath[pos].transform.position == monster.transform.position && waiting && !started){
            onPath = false;
            StartCoroutine(Wait());
        }

        
    }

    //get the enemy to stand for some time
    IEnumerator Wait(){
        started = true;
        float delay = rnd.Next(1,5);
        float timePassed = 0f;
        while(timePassed < delay){
            timePassed += Time.deltaTime;
            yield return null; 
        }
        started = false;
        waiting = false;

    }

    //decide what path to travel randomly
    private void ChangePath(){
        int next = rnd.Next(7);
        if(next == 0){
            currentPath = storagePath;

        }else if(next == 1){
            currentPath = gymPath;

        }else if(next == 2){
            currentPath = wepPath;

        }else if(next == 3){
            currentPath = engPath;

        }else if(next == 4){
            currentPath = dormPath;

        }else if (next == 5){
            currentPath = cafPath;

        }else if (next == 6){
            currentPath = medPath;
        }
        pos = 0;
    }

    //randomly change the position of the enemy
    public void RestartPattern(){
        ChangePath();
        monster.GetComponent<Transform>().position = currentPath[0].GetComponent<Transform>().position;
        waiting = false;
        onPath = false;
        started = false;

    }


    // move the monster to the closest(5%), second closest(45%) or thrid closest(50%) room to the player
    private void MoveToClosestRoom(){
        List<GameObject> points = storagePath;
        float distance = (storagePath[0].transform.position - player.transform.position).magnitude;
        List<GameObject> points2 = storagePath;
        float distance2 = 200f;
        List<GameObject> points3 = storagePath;
        float distance3 = 200f;

        float tempDistance = (gymPath[0].transform.position - player.transform.position).magnitude;
        if(tempDistance < distance){
            distance3 = distance2;
            distance2 = distance;
            distance = tempDistance;
            points3 = points2;
            points2 = points;
            points = gymPath;
        }else if(tempDistance < distance2){
            distance3 = distance2;
            distance2 = tempDistance;
            points3 = points2;
            points2 = gymPath;
        }else if(tempDistance < distance3){
            distance3 = tempDistance;
            points3 = gymPath;
        }

        tempDistance = (wepPath[0].transform.position - player.transform.position).magnitude ;
        if(tempDistance < distance){
            distance3 = distance2;
            distance2 = distance;
            distance = tempDistance;
            points3 = points2;
            points2 = points;
            points = wepPath;
        }else if(tempDistance < distance2){
            distance3 = distance2;
            distance2 = tempDistance;
            points3 = points2;
            points2 = wepPath;
        }else if(tempDistance < distance3){
            distance3 = tempDistance;
            points3 = wepPath;
        }

        tempDistance = (engPath[0].transform.position - player.transform.position).magnitude;
        if( tempDistance < distance){
            distance3 = distance2;
            distance2 = distance;
            distance = tempDistance;
            points3 = points2;
            points2 = points;
            points = engPath;
        }else if(tempDistance < distance2){
            distance3 = distance2;
            distance2 = tempDistance;
            points3 = points2;
            points2 = engPath;
        }else if(tempDistance < distance3){
            distance3 = tempDistance;
            points3 = engPath;
        }

        tempDistance = (dormPath[0].transform.position - player.transform.position).magnitude;
        if(tempDistance < distance){
            distance3 = distance2;
            distance2 = distance;
            distance = tempDistance;
            points3 = points2;
            points2 = points;
            points = dormPath;
        }else if(tempDistance < distance2){
            distance3 = distance2;
            distance2 = tempDistance;
            points3 = points2;
            points2 = dormPath;
        }else if(tempDistance < distance3){
            distance3 = tempDistance;
            points3 = dormPath;
        }

        tempDistance = (cafPath[0].transform.position - player.transform.position).magnitude;
        if(tempDistance < distance){
            distance3 = distance2;
            distance2 = distance;
            distance = tempDistance;
            points3 = points2;
            points2 = points;
            points = cafPath;
        }else if(tempDistance < distance2){
            distance3 = distance2;
            distance2 = tempDistance;
            points3 = points2;
            points2 = cafPath;
        }else if(tempDistance < distance3){
            distance3 = tempDistance;
            points3 = cafPath;
        }

        tempDistance = (medPath[0].transform.position - player.transform.position).magnitude;
        if(tempDistance < distance){
            distance3 = distance2;
            distance2 = distance;
            distance = tempDistance;
            points3 = points2;
            points2 = points;
            points = medPath;
        }else if(tempDistance < distance2){
            distance3 = distance2;
            distance2 = tempDistance;
            points3 = points2;
            points2 = medPath;
        }else if(tempDistance < distance3){
            distance3 = tempDistance;
            points3 = medPath;
        }

        int option = rnd.Next(1,101);

        if(option <= 5){
            currentPath = points;
        }else if(option <= 50){
            currentPath = points2;
        }else{
            currentPath = points3;
        }
        pos = 0;
    }
}
