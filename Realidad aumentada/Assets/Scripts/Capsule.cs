using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    public Animator anim;
    public GameObject capsule;
    public LayerMask unitSelected;
    Vector3 mouseInitialPosition;
    Camera thisCamera;//variable para obtener este componente
    // Start is called before the first frame update
    void Start()
    {
        thisCamera = GetComponent<Camera>();
        anim.SetBool("Transicion", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("boton izquierdo");
            mouseInitialPosition = thisCamera.ScreenToViewportPoint(Input.mousePosition);
            RaycastHit rayHit;//fisicas raycast(objetos que tengan un collider)
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, unitSelected))//guardar el resultado del rayo en "rayhit", si colisiono con algo nos retorna verdadero
            {
                Debug.Log("capsula");
                anim.SetBool("Transicion", true);
                StartCoroutine("FinAnimacion");
            }
        }
        
    }
    IEnumerator FinAnimacion()
    {
        yield return new WaitForSeconds(2.29f);
        anim.SetBool("Transicion", false);
    }
}
