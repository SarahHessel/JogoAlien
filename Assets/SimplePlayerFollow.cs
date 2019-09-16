using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerFollow : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }


    }
}
