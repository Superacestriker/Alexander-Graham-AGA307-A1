using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    public Transform[] spawnPoints;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.I))
            SpawnTarget();
		
    }

    void SpawnTarget()
	{
        //Pick random target and position
        int rTarget = Random.Range(0, targetPrefabs.Length);
        int rSpawn = Random.Range(0, spawnPoints.Length);
        //Spawn the target at the postion
        Instantiate(targetPrefabs[rTarget], spawnPoints[rSpawn].position, Quaternion.identity);
    }
}
