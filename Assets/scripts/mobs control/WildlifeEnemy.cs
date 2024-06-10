using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildlifeEnemy : MonoBehaviour
{
    public float radius, stoppingDist;
    public static float damage = 10f;
    private float speed = 4f, BiteRange = 3f;
    public GameObject player,normalForm, attackForm,attackArea,Jaw;
    private bool canBite = true;

    private void Start() {
        normalForm.SetActive(true);
        attackForm.SetActive(false);
    }

    void Update()
    {
       Attack();
    }

    void Attack(){
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius); //range of perception of enemy
        foreach (Collider2D collider2D in hitColliders)//iterate throught colliders detected in range
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position); //calculating distance to player
            if(collider2D.CompareTag("Player")){ //do logic when collider tag is ,,Player"
                if (distanceToPlayer > stoppingDist) // if distance to player is greater than stoppingDist; engange
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); // move towards player transform
                    Vector3 directionToPlayer = player.transform.position - transform.position;  
                    float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg; //all of these three lines are for calculating rotation towards player
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                }

                if(distanceToPlayer == stoppingDist && canBite){ //if distanceToPlayer is equal to stoppingDist and bool value canBite is true; do logic
                    RaycastHit2D raycastHit2D = Physics2D.Raycast(Jaw.transform.position, Jaw.transform.forward, BiteRange);//declaring Raycast 

                    if(raycastHit2D.collider != null){ //if raycast hit something
                        PlayerManager playerManager = raycastHit2D.transform.GetComponent<PlayerManager>(); //PlayerManager constructor

                        if(playerManager != null){
                            playerManager.UpdateHealth(damage); //update player health
                        } 
                    }
                }
                /*else 
                {
                    Vector3 directionToPlayer = player.transform.position - transform.position;
                    float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg; 
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                }*/
                
                normalForm.SetActive(false);
                attackForm.SetActive(true);
            }
        }
    }

    //cooldown for attack 
    IEnumerator BiteCooldown(){ 
        canBite = false;
        yield return new WaitForSeconds(0.5f);
        canBite = true;
    }

    //drawing range of perception of enemy in editor
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    /*void Retreat(){
        Vector2 retreat = transform.position - player.transform.position;
        retreat.Normalize();
    }*/
}
