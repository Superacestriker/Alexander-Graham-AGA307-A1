using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour
{
    public GameObject sphere;   //The object we wish to change
    public Color defaultColor;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //change the spheres colour to green
            sphere.GetComponent<Renderer>().material.color = new Color(0f, 200f, 0f);
            //Increas the spheres scale by 0.01 on all axis
            sphere.transform.localScale = new Vector3(2f, 2f, 2f);

        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //set the spheres size back to 1
            //Change the spheres colour to yellow
            sphere.GetComponent<Renderer>().material.color = defaultColor;
            sphere.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }
}

