using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle5 : MonoBehaviour
{
    public float launchForce = 1000;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        rb.AddForce(launchForce*transform.right );
        
    }
}
