using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Transform Mov;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Mov = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    public void Movimiento()
    {
        if(Input.GetKey (KeyCode.W))
        {
            Mov.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Mov.Translate(new Vector3(0, 0, -speed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Mov.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Mov.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
        }
    }
}
