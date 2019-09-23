using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PernasControl : MonoBehaviour
{
    MoveToRef script;
    public GameObject player;

    void Start()
    {
        script = player.GetComponent<MoveToRef>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Platforms") || other.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
             script.noChao = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Platforms") || other.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
            script.noChao = false;
        }
    }
}
