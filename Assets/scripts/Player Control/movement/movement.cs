using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject player;
    public swimming dive;
    public swimmingonsurface swim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S)) dive.Diving();
        else if (player.transform.position[1] >= -0.2) swim.Swim();
        else dive.Diving();
    }
}
