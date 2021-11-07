using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public TargetSize targetSize;
    public int health = 3;
    public float size;
    public GameObject gManager;
    public GameObject uiMan;


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
    public GameObject coloredObject;
    Vector3 centre;

    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.Find("GameManager");
        uiMan = GameObject.Find("Ui Manager");
        SetTargetSize();
        centre = this.transform.position;
        StartCoroutine(Teleport());
        

        switch (gManager.GetComponent<GameManager>().difficulty)
        {
            case Difficulty.Easy:
                targetSize = TargetSize.Large;
                SetTargetSize();
                break;
            case Difficulty.Medium:
                targetSize = TargetSize.Medium;
                SetTargetSize();
                break;
            case Difficulty.Hard:
                targetSize = TargetSize.Small;
                SetTargetSize();
                break;
        }
    }

    void SetTargetSize()
    {
        int enumAsInt = (int) targetSize;
        float size = sizes[enumAsInt];
        this.transform.localScale = Vector3.one * size;

        
        switch (targetSize)
        {
            case TargetSize.Small:
                coloredObject.GetComponent<Renderer>().material.color = Color.red;
                break;
            case TargetSize.Medium:
                coloredObject.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case TargetSize.Large:
                coloredObject.GetComponent<Renderer>().material.color = Color.green;
                break;
        }
        

        
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(3);

        float height = Random.Range(1.5f, 3.5f);
        this.transform.position = new Vector3(this.transform.position.x, height, this.transform.position.z);

        StartCoroutine(Teleport());
    }

    // Update is called once per frame
    void Update()
    {
        // this is a bad idea but it will solve the dropdown problem
        switch (gManager.GetComponent<GameManager>().difficulty)
        {
            case Difficulty.Easy:
                targetSize = TargetSize.Large;
                SetTargetSize();
                break;
            case Difficulty.Medium:
                targetSize = TargetSize.Medium;
                SetTargetSize();
                break;
            case Difficulty.Hard:
                targetSize = TargetSize.Small;
                SetTargetSize();
                break;
        }
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
                int enumAsInt = (int)targetSize;
                float size = sizes[enumAsInt];
                float pointValue = 20f / size;
                uiMan.GetComponent<UiManager>().TargetNumberChange(-1);
                Destroy(this.gameObject);
                gManager.GetComponent<GameManager>().AddTime(5);
                gManager.GetComponent<GameManager>().AddScore((int) pointValue);
            }
            
        }
        print("hit");
	}
}
