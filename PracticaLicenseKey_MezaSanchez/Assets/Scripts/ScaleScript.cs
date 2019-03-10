using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScript : MonoBehaviour
{

    public float limMax; //.5f
    public float limMin; //.15f
    public float scaleNumber; //.05f
    public Camera thisCamera;
    public GameObject scaledObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScaleObj()
    {
        scaledObj.transform.localScale = new Vector3(scaledObj.transform.localScale.x + scaleNumber, scaledObj.transform.localScale.y + scaleNumber, scaledObj.transform.localScale.z + scaleNumber);
        if (scaledObj.transform.localScale.x >= limMax)
        {
            scaledObj.transform.localScale = new Vector3(limMax, limMax, limMax);
        }
        else if(scaledObj.transform.localScale.x <= limMin)
        {
            scaledObj.transform.localScale = new Vector3(limMin, limMin, limMin);
        }
    }
}
