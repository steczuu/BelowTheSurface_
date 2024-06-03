using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static float PlayerHp = 100f;
    public void UpdateHealth(float damage){
        PlayerHp -= damage;
        if(PlayerHp <= 0){
           // isAlive = false;
           // SceneManagement.ResetScene();
        }
    }
}
