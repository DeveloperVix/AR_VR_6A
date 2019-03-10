using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour
{
    public GameObject objetoxd;
   // public Animator Escala11;

    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 2f;                                                  
    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    public virtual void Movimiento()                                                 
    {
        objetoxd.transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime); 
        if (objetoxd.transform.position == waypoints[waypointIndex].transform.position)  
        {
            waypointIndex += 1;                                               
        }
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    public virtual void Movimiento2()
    {
        objetoxd.transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        if (objetoxd.transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    public virtual void Movimiento3()
    {
        objetoxd.transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        if (objetoxd.transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    /* public void Escala1()
     {
         Escala11.SetBool("entrada", true);
     }*/
     

}
