using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week1 : MonoBehaviour
{
    public int numA;
    public int numB;
    public int result;
    // Start is called before the first frame update
    void Start()
    {
        //result = Sum(numA, numB);

        if(numA > numB)
		{
            Debug.Log("NumA is bigger than NumB");
            numA = numB - 1;
		}
        else if(numA < numB)
        {
            Debug.Log("NumA is smaller than NumB");
            numA = numB + 1;
        }
        else
        {
            Debug.Log("NumA is equal to NumB");

        }
    }

    
    /*int Sum(int a, int b)
	  {
        return a + b;
      
        
     }
     */
}
