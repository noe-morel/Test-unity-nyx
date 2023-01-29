using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position-4*player.transform.forward+4*Vector3.up;
        transform.LookAt(player.transform.position+3*player.transform.forward,Vector3.up);
    }
}
