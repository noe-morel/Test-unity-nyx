using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_ray : MonoBehaviour
{
    public GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position+player.transform.forward;
        Quaternion rotation = Quaternion.LookRotation(player.transform.up, player.transform.forward);
        transform.rotation = rotation;
    }
}
