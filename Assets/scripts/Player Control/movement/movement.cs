using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    float damping = 0.02f;                   // ResistanceOfMedium
    float acceleration = 0.02f;              // Having lower a than damping will stop movement, also if a wont be divisble by damping value, it will cause a bug likely
    float MaxSpeed = 5f;
    Vector2 Velocity = new Vector2(0f,0f);  //first vertical, second horizontal
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            if (Velocity[0] < MaxSpeed) Velocity[0] += 0.01f;      //accelerating
        if (Input.GetKey(KeyCode.S))
            if (Velocity[0] < MaxSpeed) Velocity[0] -= 0.01f;      //accelerating
        if (Input.GetKey(KeyCode.A))
            if (Velocity[1] < MaxSpeed) Velocity[1] -= 0.01f;      //accelerating
        if (Input.GetKey(KeyCode.D))
            if (Velocity[1] < MaxSpeed) Velocity[1] += 0.01f;      //accelerating

        if (!(Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.D))){
            if (Velocity[0] != 0){              //decelerating
                if (Velocity[0] > 0)        Velocity[0] -= damping;
                else                        Velocity[0] += damping;
            }
            if (Velocity[1] != 0){             //decelerating
                if (Velocity[1] > 0)        Velocity[1] -= damping;
                else                        Velocity[1] += damping;
            }
        }

                                                //moving
        transform.position = transform.position + new Vector3(0, Velocity[0] * Time.deltaTime, 0);
        transform.position = transform.position + new Vector3(Velocity[1] * Time.deltaTime, 0, 0);

    }
}
