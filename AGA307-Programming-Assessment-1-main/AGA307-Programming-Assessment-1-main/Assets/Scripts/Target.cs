using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Projectile")
		{
            health = health - 1;
            if(health <= 0)
            {
                Destroy(this.gameObject);
            }
            
        }
        print("hit");
	}
}
