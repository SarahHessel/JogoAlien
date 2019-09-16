using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilcontrol : MonoBehaviour
{
    public GameObject prefab;
   


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            Destroy(gameObject);


        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Coletaveis"))
        {
            Destroy(gameObject);


        }
    }
    }