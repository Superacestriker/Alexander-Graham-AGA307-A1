using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;
    public List<GameObject> enemies;

    

    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < spawnPoints.Length; i++)
		{
            int rNum = Random.Range(0, enemyTypes.Length);
            GameObject e = Instantiate(enemyTypes[rNum], spawnPoints[i].position, spawnPoints[i].rotation);
            enemies.Add(e);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
