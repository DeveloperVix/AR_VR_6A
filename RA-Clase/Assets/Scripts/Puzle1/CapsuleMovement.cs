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
    protected seleccionFigura selFig;

    GameObject cameraObj;
    protected Camera camera;
    public RaycastHit hit;
    public int contador;
    public GameObject Capsule;
    

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        statusImg = GetComponent<DefaultTrackableEventHandler>();
        agente = gameObject.GetComponent<NavMeshAgent>();
        cameraObj = GameObject.Find("ARCamera");
        camera = cameraObj.GetComponent<Camera>();
        selFig = gameObject.GetComponent<seleccionFigura>();
    }

    // Update is called once per frame
    void Update()
    {
        Animator anima = Capsule.GetComponent<Animator>();
        bool victory = anima.GetBool("Victory");

        if(statusImg)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Clic derecho");
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit) && selFig.estaSeleccionada)
                {
                    Debug.Log(hit.collider.gameObject.layer);
                    target = hit.point;
                    agente.SetDestination(target);
                }
            }
        }

        if(contador >= 2)
        {
            anima.SetBool("Victory", victory = true);
            GameObject GameObj = GameObject.Find("GameController");
            GameControllerARGame game = GameObj.GetComponent<GameControllerARGame>();
            game.PuzlesCompletados++;
        }
        
    }
}
