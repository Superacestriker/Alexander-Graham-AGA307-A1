using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public TargetSize targetSize;
    public int health = 3;
    public float size;
    
    public float[] sizes = new float[]
	{
        0.5f,
        1,
        2
	};
    

    [Header("Movement")]
    public int[] speeds = new int[]
    {
        1,
        2,
        3
    };
public int strafeDistance = 3;
    Vector3 centre;

    // Start is called before the first frame update
    void Start()
    {
       
        SetTargetSize();
        centre = this.transform.position;
        
    }

    void SetTargetSize()
    {
        int enumAsInt = (int) targetSize;
        float size = sizes[enumAsInt];
        this.transform.localScale = Vector3.one * size;

        /*
        switch (targetSize)
        {
            case TargetSize.Small:
                size = 0.5f;
                speed = 2f;
                break;
            case TargetSize.Medium:
                size = 1f;
                speed = 1f;
                break;
            case TargetSize.Large:
                size = 2f;
                speed = 0.5f;
                break;
        }
        */

        
    }

    

    // Update is called once per frame
    void Update()
    {
        Move();

		if (Input.GetKeyDown(KeyCode.R))
		{
            //randomise the value of target size
            targetSize = (TargetSize) (int)Random.Range(0,3);
            SetTargetSize();
		}
    }

    void Move()
	{
        Vector3 targetPos = centre + (Vector3.left * strafeDistance);
        if(this.transform.position != targetPos)
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, speeds[(int)targetSize] * Time.deltaTime);
        else
            strafeDistance  *= -1;
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
