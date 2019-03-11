using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SimonAr : MonoBehaviour
{

    DefaultTrackableEventHandler juegoStatus;
    private MeshRenderer meshRenderer;

    protected Camera cam;
    [SerializeField]
    protected Material blue, red, yellow, green;

    public int ColorSeleccionado, eleccionSimon;
    public RaycastHit hit;
    GameObject camaraObj;


    // Start is called before the first frame update
    void Start()
    {
        camaraObj = GameObject.Find("ARCamera");
        cam = camaraObj.GetComponent<Camera>();
        juegoStatus = GetComponent<DefaultTrackableEventHandler>();
        StartCoroutine(InicioJuego());
    }

    // Update is called once per frame
    void Update()
    {
        if (juegoStatus)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit))
                {

                    
                }
            }
        }
    }

    

    IEnumerator InicioJuego()
    {
        if (juegoStatus.isDetected)
        {
            ColorSeleccionado = (int)Random.Range(1.0f, 4.0f);

            switch (ColorSeleccionado)
            {
                case 1:
                    meshRenderer.material = blue;
                    eleccionSimon = 1;
                    break;
                case 2:
                    meshRenderer.material = red;
                    eleccionSimon = 2;
                    break;
                case 3:
                    meshRenderer.material = yellow;
                    eleccionSimon = 3;
                    break;
                case 4:
                    meshRenderer.material = green;
                    eleccionSimon = 4;
                    break;
            }

            yield return new WaitForSeconds(10.0f);

            StartCoroutine(endGame());
        }
        else
        {
            StartCoroutine(InicioJuego());
        }

        
    }

    IEnumerator endGame()
    {
        gameObject.SetActive(false);

        yield return null;
    }
}
