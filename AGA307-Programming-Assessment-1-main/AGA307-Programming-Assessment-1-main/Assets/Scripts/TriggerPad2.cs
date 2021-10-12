using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad2 : MonoBehaviour
{
    public GameObject sphere;   //The object we wish to change


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            

        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
                sphere.transform.localScale = new Vector3(1f, 1f, 1f);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }
}
