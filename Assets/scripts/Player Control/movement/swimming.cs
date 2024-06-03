using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swimming : MonoBehaviour
{
    float damping = 0.01f;                   // ResistanceOfMedium
    float acceleration = 0.024f;              // Having lower a than damping will stop movement, also if a wont be divisble by damping value, it will cause a bug likely
    float MaxSpeed = 2f;                     // Preatty much unused rn if u wanna change it, change cycle duration & acceleration & damping
    public Vector2 Velocity = new Vector2(0f,0f);   //first vertical, second horizontal
    int i = 0;                               //used for dynamic swimming
    int CycleDuration = 500;
    private bool moving = false;
    public void Diving()
    {
        moving = false;
        if (Input.GetKeyDown(KeyCode.LeftShift)) MaxSpeed = 4f; CycleDuration = 300;  //sprint
        if (Input.GetKeyUp(KeyCode.LeftShift))  MaxSpeed = 2f; CycleDuration = 500; 
        Debug.Log(i);
        if (i > CycleDuration)  i = 0;       //cycle timer and truncation error correcting
        if (Input.GetKey(KeyCode.W)){
            if (Velocity[0] < MaxSpeed && i<=100) Velocity[0] += acceleration;      //accelerating
            moving = true;
        }
        if (Input.GetKey(KeyCode.S)){
            if (Velocity[0] < MaxSpeed && i <= 100) Velocity[0] -= acceleration;      //accelerating
            moving = true;
        }
        if (Input.GetKey(KeyCode.A)){
            if (Velocity[1] < MaxSpeed && i <= 100) Velocity[1] -= acceleration;      //accelerating
            moving = true;
        }
        if (Input.GetKey(KeyCode.D)){
            if (Velocity[1] < MaxSpeed && i <= 100) Velocity[1] += acceleration;      //accelerating
            moving = true;
        }


        if (!(moving) | i > 100){
            if (Velocity[0] >= -damping && Velocity[0] <= damping) Velocity[0] = 0;  //truncation handler
            if (Velocity[1] >= -damping && Velocity[1] <= damping) Velocity[1] = 0; //truncation handler
            if (Velocity[0] != 0){              //decelerating
                if (Velocity[0] > 0)        Velocity[0] -= damping;
                else                        Velocity[0] += damping;
            }
            if (Velocity[1] != 0){             //decelerating
                if (Velocity[1] > 0)        Velocity[1] -= damping;
                else                        Velocity[1] += damping;
            }
            i++;
        }
        else i++;
        
        //moving
        transform.position = transform.position + new Vector3(Velocity[1] * Time.deltaTime, Velocity[0] * Time.deltaTime, 0);
    }
    
}
