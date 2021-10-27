using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float moveDistance = 500;

    public EnemyType enemyType;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
        if(enemyType == EnemyType.Archer)
		{
            health = 50;
		}
        if (enemyType == EnemyType.OneHanded)
        {
            health = 100;
        }
        if (enemyType == EnemyType.TwoHanded)
        {
            health = 200;
        }

		switch(enemyType)
		{
            case EnemyType.Archer:
                health = 50;
                break;
            case EnemyType.OneHanded:
                health = 100;
                break;
            case EnemyType.TwoHanded:
                health = 200;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            GameManager.instance.AddScore(5);
    }

    IEnumerator Move()
	{
        for(int i = 0; i < moveDistance; i++)
		{
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
            
		}
        transform.Rotate(Vector3.up * 180);
        yield return new WaitForSeconds(3);
        StartCoroutine(Move());
    }
}

public enum EnemyType
{
    Archer,
    OneHanded,
    TwoHanded
}

