using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Vuforia;

public class CapsuleMovement : MonoBehaviour
{


    DefaultTrackableEventHandler statusImg;
    protected NavMeshAgent agente;
    protected Vector3 target;

    GameObject cameraObj;
    protected Camera camera;
    public RaycastHit hit;
    

    // Start is called before the first frame update
    void Start()
    {
        statusImg = GetComponent<DefaultTrackableEventHandler>();
        agente = gameObject.GetComponent<NavMeshAgent>();
        cameraObj = GameObject.Find("ARCamera");
        camera = cameraObj.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(statusImg.isDetected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Clic izquierdo");
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    target = hit.point;
                    agente.SetDestination(target);
                }
            }
        }
        
        
    }
}
