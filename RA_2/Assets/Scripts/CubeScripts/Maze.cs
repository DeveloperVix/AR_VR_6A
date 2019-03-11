using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    Vector3 InitialPosition;

    [Header("Puntos obtenibles de la prueba")]
    public int Points = 0;

    public int Restantes = 9;
    public BoxCollider[] gemas;
    public GameObject[] gems;

    public Transform[] targets;
    public GameObject[] points;
    public GameObject[] Cube;
    Rigidbody rb;

    public int vel = 5;

    // Start is called before the first frame update
    void Start()
    {
        
        /*rb = GetComponent<Rigidbody>();
        for (int i = 0; i < points.Length; i++)
        {
            Cube[i] = GetComponent<GameObject>();
        }
        InitialPosition = rb.transform.position;*/
        //TargetPositions();
    }

    // Update is called once per frame
    void Update()
    {
        //MoveToWaypoint();
    }

    public void MoveToWaypoint()
    {

        /*for (int i = 0; i < Waypoints.Length; i++)
        {
            if (rb.transform.position != Waypoints[i].transform.position)
            {
                
                //rb.transform.position = Waypoints[i].transform.position;
            }
        }*/
        float step = vel * Time.deltaTime; // calculate distance to move
        for (int i = 0; i < targets.Length; i++)
        {
            // Move our position a step closer to the target.
            
            transform.position = Vector3.MoveTowards(transform.position, targets[i].position, step);
            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, targets[i].position) < 0.001f)
            {
                // Swap the position of the cylinder.
                //targets[i].position *= -1.0f;
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Click");
        Destroy(gameObject);
    }
}
