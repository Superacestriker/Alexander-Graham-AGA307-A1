using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    public GameObject sphere;



    private void FixedUpdate()
    {
        RaycastHit hit; 
        
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        
        if (Physics.Raycast(transform.position, fwd, out hit, 10))
        {
            print(hit.collider.name);

            if (hit.collider.gameObject.name == ("Sphere2"))
            {

                sphere.GetComponent<Renderer>().material.color = new Color(200f, 200f, 0f);

            }
            

        }

    }

}
