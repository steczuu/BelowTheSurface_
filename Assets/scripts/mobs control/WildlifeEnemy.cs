using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildlifeEnemy : MonoBehaviour
{
    public float radius, stoppingDist;
    public static float damage = 10f;
    private float speed = 4f, BiteRange = 3f;
    public GameObject player,normalForm, attackForm,attackArea,Jaw;
    private bool hasAttacked = false;
    private bool canBite = true;

    private void Start() {
        normalForm.SetActive(true);
        attackForm.SetActive(false);
    }

    void Update()
    {
       Attack();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Attack(){
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D collider2D in hitColliders)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            if(collider2D.CompareTag("Player")){
                if (distanceToPlayer > stoppingDist) 
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                    Vector3 directionToPlayer = player.transform.position - transform.position;
                    float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                }

                if(distanceToPlayer == stoppingDist && canBite){
                    RaycastHit2D raycastHit2D = Physics2D.Raycast(Jaw.transform.position, Jaw.transform.forward, BiteRange);

                    if(raycastHit2D.collider != null){
                        PlayerManager playerManager = raycastHit2D.transform.GetComponent<PlayerManager>();

                        if(playerManager != null){
                            playerManager.UpdateHealth(damage);
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

    IEnumerator BiteCooldown(){
        canBite = false;
        yield return new WaitForSeconds(0.5f);
        canBite = true;
    }

    /*void Retreat(){
        Vector2 retreat = transform.position - player.transform.position;
        retreat.Normalize();
    }*/
}
