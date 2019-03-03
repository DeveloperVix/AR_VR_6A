using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ARController : MonoBehaviour
{
    
    public Camera cam;
    public Transform[] waypoints = new Transform[4];
    public GameObject capsula;
    public int speed;
    int currentPoint;
    public LayerMask layer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Debug.Log("Click");
            if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition),out hit, Mathf.Infinity, layer))
            {
                Debug.Log("SegundoIF");
                for (int i = 0; i < waypoints.Length; i++)
                {
                    if(capsula.transform.position == waypoints[currentPoint].position)
                    {
                        currentPoint = (currentPoint + 1) % waypoints.Length;
                    } 
                }
            }
        }
        capsula.transform.position = Vector3.MoveTowards(capsula.transform.position, waypoints[currentPoint].position, speed * Time.deltaTime);

      
    }
}
