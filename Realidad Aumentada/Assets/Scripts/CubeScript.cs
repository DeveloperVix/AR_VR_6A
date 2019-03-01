using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public GameObject cube;
    public LayerMask cubeSelected;

    Camera thisCamera;

    Vector3 mouseInitialPosition;

    public Animator anim;

    bool animPlaying = false;

    
    public DefaultTrackableEventHandler statusAnim;


    void Awake()
    {
        thisCamera = GetComponent<Camera>();//accedemos a los componentes
        //statusImg = GetComponent<DefaultTrackableEventHandler>();
        statusAnim.GetComponent<DefaultTrackableEventHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(statusAnim.isDetected == true)
        {
            
            if (Input.GetMouseButtonDown(0))//si ha sido presionado el click izquierdo
            {
                mouseInitialPosition = thisCamera.ScreenToViewportPoint(Input.mousePosition);//transforma las coordenadas de pantalla en un espacio de viewport(nos retorna coordenadas de 0 a 1)
                RaycastHit rayHit;//fisicas raycast(objetos que tengan un collider)
                if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, cubeSelected))//guardar el resultado del rayo en "rayhit", si colisiono con algo nos retorna verdadero
                {
                   anim.SetBool("animActive", true);
                }
            }
        }
        else
        {
            if(statusAnim.isDetected == false)
            {
                anim.SetBool("animActive", false);
                
            }
        }
        
    }
}
