using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota3 : MonoBehaviour
{

    public GameObject plane;

    public GameObject spawnpoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < plane.transform.position.y - 10)
        {
            transform.position = spawnpoint.transform.position;

        }
    }
}