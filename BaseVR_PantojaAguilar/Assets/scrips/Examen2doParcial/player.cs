using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform Head, mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (PoolingManager.sing.Balas.Count == 0) return;

            GameObject obj = PoolingManager.sing.CreaBalas(Head.localPosition, mainCamera.localRotation);
            obj.SetActive(true);
        }
    }
}
