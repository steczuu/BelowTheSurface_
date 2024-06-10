using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{   
    //this is temporary solution for testing purposes
    public List<string> EqItems = new List<string>();
    public static float PlayerHp = 100f;


    public void PlayerInteraction(string item){
        EqItems.Add(item);  
    }

    public void UpdateHealth(float damage){
        PlayerHp -= damage;
        if(PlayerHp <= 0){
           // isAlive = false;
           // SceneManagement.ResetScene();
        }
    }
}
