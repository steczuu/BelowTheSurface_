using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swimmingonsurface : MonoBehaviour
{
    float damping = 0.02f;                   // ResistanceOfMedium
    float acceleration = 0.02f;              // Having lower a than damping will stop movement, also if a wont be divisble by damping value, it will cause a bug likely
    float MaxSpeed = 2f;
    public Vector2 Velocity = new Vector2(0f, 0f);   //first vertical, second horizontal all vertical might be removed here
    public bool moving;
    public void Swim()
    {
        moving = false;
        if (Input.GetKeyDown(KeyCode.LeftShift))  MaxSpeed = 3.5f; //sprint
        if (Input.GetKeyUp(KeyCode.LeftShift)) MaxSpeed = 2f;

        //if (Input.GetKey(KeyCode.S)){

        //    if (Velocity[0] > -MaxSpeed) Velocity[0] -= acceleration;      //accelerating
        //    moving = true;
        //}
        if (Input.GetKey(KeyCode.A)){
            if (Velocity[1] > -MaxSpeed) Velocity[1] -= acceleration;      //accelerating
            moving = true;
        }
        if (Input.GetKey(KeyCode.D)){
            if (Velocity[1] < MaxSpeed) Velocity[1] += acceleration;      //accelerating
            moving = true;
        }

        

        if (!moving){
            if (Velocity[0] >= -damping && Velocity[0] <= damping)  Velocity[0] = 0;  //truncation handler
            if (Velocity[1] >= -damping && Velocity[1] <= damping)  Velocity[1] = 0; //truncation handler
            if (Velocity[0] != 0) {              //decelerating
                if (Velocity[0] > 0) Velocity[0] -= damping;
                else Velocity[0] += damping;
            }
        }
         //moving
        transform.position = transform.position + new Vector3(Velocity[1] * Time.deltaTime, Velocity[0] * Time.deltaTime, 0);
    }
}
