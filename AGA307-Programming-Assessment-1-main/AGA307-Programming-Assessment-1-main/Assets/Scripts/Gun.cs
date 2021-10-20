using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool useHitScan = false;
    [Header("Components and References")]
    public Projectile prefab;
    public Transform spawnPosition;
    

    public LayerMask hitMask;
    public int GunUsed = 1;

    public void Shoot()
	{
		if (useHitScan)
		{
            //determine origin and direction of ray
            Ray r = new Ray(spawnPosition.position, spawnPosition.forward);
            RaycastHit h;

            //perform ray cast if hit draw green line otherwise red one
            if(Physics.Raycast(r, out h, 10, hitMask))
			{
                Debug.DrawLine(r.origin, h.point, Color.green, 0.125f);
			}
			else
			{
                Debug.DrawRay(r.origin, r.direction * 10, Color.red, 0.125f);
			}
		}
        else
            //spawn the bullet at tip of gun
            Instantiate(prefab, spawnPosition.position, spawnPosition.rotation);
            
		
	}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
