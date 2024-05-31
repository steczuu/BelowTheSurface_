using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    float damping = 0.01f;                   // ResistanceOfMedium
    float acceleration = 0.02f;              // Having lower a than damping will stop movement, also if a wont be divisble by damping value, it will cause a bug likely
    float MaxSpeed = 2f;                     
    public Vector2 Velocity = new Vector2(0f,0f);   //first vertical, second horizontal
    int i = 0;                               //used for dynamic swimming
    int CycleDuration = 500;
    public bool moving = false;
    void Start()
    {
        
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.LeftShift)) {MaxSpeed = 5f; CycleDuration = 300; } //sprint
        if (Input.GetKeyUp(KeyCode.LeftShift)) {MaxSpeed = 2f; CycleDuration = 500; }

        if (i > CycleDuration) i = 0;        //cycle timer
        if (i <= 100) {
            if (Input.GetKey(KeyCode.W)) {
                if (Velocity[0] < MaxSpeed) Velocity[0] += acceleration;      //accelerating
                moving = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (Velocity[0] < MaxSpeed) Velocity[0] -= acceleration;      //accelerating
                moving = true;
            }
            if (Input.GetKey(KeyCode.A)) { 
                if (Velocity[1] < MaxSpeed) Velocity[1] -= acceleration;      //accelerating
                moving = true;
            }
            if (Input.GetKey(KeyCode.D)) { 
                if (Velocity[1] < MaxSpeed) Velocity[1] += acceleration;      //accelerating
                moving = true;
            }
        }

        //if ((Velocity[0] < 0.001f) && (Velocity[0] > -0.001f)) { Velocity[0] = 0f; Debug.Log("Correcting"); }

        if (!(moving)|i>100){
            if (Velocity[0] != 0){              //decelerating
                if (Velocity[0] > 0)        Velocity[0] -= damping;
                else                        Velocity[0] += damping;
                i++;
            }
            if (Velocity[1] != 0){             //decelerating
                if (Velocity[1] > 0)        Velocity[1] -= damping;
                else                        Velocity[1] += damping;
                i++;
            }
        }
        else i++;
                                                                 //moving
        transform.position = transform.position + new Vector3(Velocity[1] * Time.deltaTime, Velocity[0] * Time.deltaTime, 0);
        //Debug.Log(Velocity[1]);
        //Debug.Log(Velocity[0]);
    }
}
