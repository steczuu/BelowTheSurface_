using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float smoothSpeed = 0.005f;
    public Transform player;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + new Vector3(0,0,-10), smoothSpeed); //smoothly follows the player with offset of -10 (as it was by default) in z plane
    }
}
