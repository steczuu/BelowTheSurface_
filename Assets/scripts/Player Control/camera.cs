using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float smoothSpeed = 0.015f;
    public GameObject player;
    Vector3 offset = new Vector3(0, 0, -10);
    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, smoothSpeed); //smoothly follows the player with offset of -10 (as it was by default) in z plane
    }
}
