﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballscript : MonoBehaviour
{
    public GameObject plane;

    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < plane.transform.position.y - 1)
        {
            transform.position = spawnPoint.transform.position;
        }
        
    }
}
