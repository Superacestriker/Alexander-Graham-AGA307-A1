using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public TargetSize targetSize;
    public int health = 3;
    float size = 1;
    float moveDistance = 500;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
        SetUp();
    }

    void SetUp()
    {
        switch (targetSize)
        {
            case TargetSize.Small:
                size = 0.5f;
                transform.localScale = Vector3.one * size;
                break;
            case TargetSize.Medium:
                size = 1f;
                transform.localScale = Vector3.one * size;
                break;
            case TargetSize.Large:
                size = 2f;
                transform.localScale = Vector3.one * size;
                break;
        }
    }

    IEnumerator Move()
    {
        for (int i = 0; i < moveDistance; i++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;

        }
        transform.Rotate(Vector3.up * 180);
        yield return new WaitForSeconds(3);
        StartCoroutine(Move());
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
