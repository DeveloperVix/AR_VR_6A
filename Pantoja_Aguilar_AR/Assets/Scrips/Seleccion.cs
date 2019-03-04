using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccion : MonoBehaviour
{
    public LayerMask unitSelected;
    Camera thisCamera;
    public List<GameObject> currentSelected;
    public List<GameObject> unitsToSelect;
    Vector2 touchDeltaPosition;
    Vector3 mouseInitialPosition;
    Vector3 mouseFinalPosition;
    Animator _animator;

    // Use this for initialization
    void Awake()
    {
        thisCamera = GetComponent<Camera>();
        currentSelected = new List<GameObject>();
        unitsToSelect = new List<GameObject>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            mouseInitialPosition = thisCamera.ScreenToViewportPoint(Input.mousePosition);

            RaycastHit rayHit;
            if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, unitSelected))
            {
                Status unitStatus = rayHit.collider.GetComponent<Status>();
                if (Input.GetKey("left ctrl"))
                {
                    if (!unitStatus.isSelected)
                    {
                        currentSelected.Add(rayHit.collider.gameObject);
                        unitStatus.isSelected = true;
                        unitStatus.dateSelected();
                    }
                    else
                    {
                        currentSelected.Add(rayHit.collider.gameObject);
                        unitStatus.isSelected = false;
                        unitStatus.dateSelected();
                    }
                }
                else
                {
                    //limpiara la ista de objetos seleccionados
                    CleanCurrentSelection();

                    currentSelected.Add(rayHit.collider.gameObject);
                    unitStatus.isSelected = true;
                    unitStatus.dateSelected();
                }
            }
            else //if (!Input.GetKey("left ctrl"))
            {
                //limpiar la lista de objetos seleccionadosa
                CleanCurrentSelection();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseFinalPosition = thisCamera.ScreenToViewportPoint(Input.mousePosition);
            if (mouseInitialPosition != mouseFinalPosition)
            {
                SelectUnits();
            }
        }*/
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        _animator.SetBool("movimiento1", true);
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() != Physics2D.OverlapPoint(touchPos))
                    {
                        _animator.SetBool("movimiento1", false);
                    }
                    break;
                case TouchPhase.Ended:
                    _animator.SetBool("movimiento1", false);
                    break;
            }

        }
    }

    void SelectUnits()
    {
        if (Input.GetKey("left ctrl") == false)
        {
            CleanCurrentSelection();
        }
        Rect boxSlect = new Rect(mouseInitialPosition.x, mouseInitialPosition.y,
                                 mouseFinalPosition.x - mouseInitialPosition.x,
                                 mouseFinalPosition.y - mouseInitialPosition.y);
        foreach (GameObject unitObject in unitsToSelect)
        {
            if (boxSlect.Contains(thisCamera.WorldToViewportPoint(unitObject.transform.position), true))
            {
                currentSelected.Add(unitObject);
                unitObject.GetComponent<Status>().isSelected = true;
                unitObject.GetComponent<Status>().dateSelected();
            }
        }
    }

    void CleanCurrentSelection()
    {
        //si hay mas de un objetp que preguntar cuantos objetos
        if (currentSelected.Count >= 1)
        {
            foreach (GameObject unidadActual in currentSelected)
            {
                unidadActual.GetComponent<Status>().isSelected = false;
                unidadActual.GetComponent<Status>().dateSelected();
            }
            currentSelected.Clear();
        }
    }
}
