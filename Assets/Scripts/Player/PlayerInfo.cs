using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    private bool isHiding = false;
    private float maxHealth = 100;
    private float health;
    
    public Image bar;

    public bool GetHidingStatus(){
        return isHiding;
    }
    public void IsHiding(){
        isHiding = true;
    }
    public void NotHiding (){
        isHiding = false;
    }

    void Start(){
        health = maxHealth;
    }

    void Update(){
        
        bar.rectTransform.localScale = new Vector3((health/100),1f,1f);
        if(health > 0 && health < maxHealth){
            float level = health + (Time.deltaTime / 1f);
            bar.rectTransform.localScale = new Vector3((level/100),1f,1f);
        }
    }

    public void DamageTaken(float amount){
        health -= amount;
        if(health <= 0){
            health = 1;
            GameOver();
        }
    }

    public void HealthGained(float amount){
        health += amount;
        if (health > maxHealth){
            health = maxHealth;
        }
    }

    private void GameOver(){
        SceneManager.LoadScene("Player Died");
    }
}
