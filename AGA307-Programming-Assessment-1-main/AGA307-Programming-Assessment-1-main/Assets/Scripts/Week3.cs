using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3 : MonoBehaviour
{
    public string[] playerNames;

    public int[] numbers = new int[3];

    
    // Start is called before the first frame update
    private void Start()
    {
        numbers[0] = numbers[1] + numbers[2];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
