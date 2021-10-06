using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Components and References")]
    public Projectile prefab;
    public Transform spawnPosition;

    public void Shoot()
	{
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
