using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 10;
    public float lifeTime = 2f;

    [Header("Components")]
    public Rigidbody RB;

    void Start()
    {
       RB = this.GetComponent<Rigidbody>();
       RB.velocity = transform.forward * speed;
       Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
	{
        Destroy(this.gameObject);
        /*   if(collision.gameObject.tag == "Target")
           {
               Destroy(collision.gameObject, 1);
           }

       }

       private void OnTriggerEnter(Collider other)
       {
           Destroy(this.gameObject);
           if (other.gameObject.tag == "Target")
           {
               Destroy(other.gameObject);
           }

       */
    }
}
