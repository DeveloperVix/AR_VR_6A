using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnpoint;

    public float speed = 0.1f;

    private Vector3 direction = Vector3.zero;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * 5;
        float v = Input.GetAxis("Vertical") * 5;

        Vector3 vel = rb.velocity;
        vel.x = h;
        vel.z = v;
        rb.velocity = vel;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "col1")
        {
            Debug.Log("Colision detectada");
            Destroy(gameObject);
            Player.transform.position = respawnpoint.transform.position;
        }

        else if (col.gameObject.name == "col2")
        {
            Debug.Log("Colision detectada");
            Destroy(gameObject);
            Player.transform.position = respawnpoint.transform.position;
        }

        else if (col.gameObject.name == "col3")
        {
            Debug.Log("Colision detectada");
            Destroy(gameObject);
           Player.transform.position = respawnpoint.transform.position;
        }

        else if (col.gameObject.name == "col4")
        {
            Debug.Log("Colision detectada");
            Destroy(gameObject);
            Player.transform.position = respawnpoint.transform.position;
        }

        else if (col.gameObject.name == "col5")
        {
            Debug.Log("Colision detectada");
            Destroy(gameObject);
            Player.transform.position = respawnpoint.transform.position;
        }

        else if (col.gameObject.name == "col6")
        {
            Debug.Log("Colision detectada");
            Destroy(gameObject);
            Player.transform.position = respawnpoint.transform.position;
        }

        else if (col.gameObject.name == "col7")
        {
            Debug.Log("Colision detectada");
            Destroy(gameObject);
            Player.transform.position = respawnpoint.transform.position;
        }

        else if (col.gameObject.name == "col8")
        {
            Debug.Log("Colision detectada");
            Destroy(gameObject);
           Player.transform.position = respawnpoint.transform.position;
        }

        else if (col.gameObject.name == "col9")
        {
            Debug.Log("Colision detectada");
            Destroy(gameObject);
            Player.transform.position = respawnpoint.transform.position;
        }

        else if (col.gameObject.name == "col10")
        {
            Debug.Log("Colision detectada");
            Destroy(gameObject);
           Player.transform.position = respawnpoint.transform.position;
        }

        else if (col.gameObject.name == "col11")
        {
            Debug.Log("Colision detectada");
            Destroy(gameObject);
            Player.transform.position = respawnpoint.transform.position;
        }

        else if (col.gameObject.name == "col12")
        {
            Debug.Log("Colision detectada");
            Destroy(gameObject);
            Player.transform.position = respawnpoint.transform.position;
        }

        else if (col.gameObject.name == "col13")
        {
            Debug.Log("Colision detectada");
            Destroy(gameObject);
            Player.transform.position = respawnpoint.transform.position;
        }

        else if (col.gameObject.name == "col14")
        {
            Debug.Log("Colision detectada");
            Destroy(gameObject);
            Player.transform.position = respawnpoint.transform.position;
        }

        else if (col.gameObject.name == "col15")
        {
            Debug.Log("Colision detectada");
            Destroy(gameObject);
            Player.transform.position = respawnpoint.transform.position;
        }

        else if (col.gameObject.name == "col16")
        {
            Debug.Log("Colision detectada");
            Destroy(gameObject);
            Player.transform.position = respawnpoint.transform.position;
        }

        else if (col.gameObject.name == "Meta")
        {
            Debug.Log("Colision detectada");
            
            Player.transform.position = respawnpoint.transform.position;
        }

    }

}
