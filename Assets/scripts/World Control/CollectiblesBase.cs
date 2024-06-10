using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesBase : MonoBehaviour
{
    public PlayerManager playerManager;
    public UI_Manager uI_Manager;
    public string itemName = "";
    bool IsPlayerInRange;

    void Update(){
        if(IsPlayerInRange && Input.GetKeyDown(KeyCode.E)){
            playerManager.PlayerInteraction(itemName);

            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            IsPlayerInRange = true;
            uI_Manager.InteractionText.text = "[E] to pickup";
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            IsPlayerInRange = false;
            uI_Manager.InteractionText.text = "";
        }
    }
}
