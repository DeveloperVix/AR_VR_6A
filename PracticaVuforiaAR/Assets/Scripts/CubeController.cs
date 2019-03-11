using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CubeController : MonoBehaviour
{

    public int indexWayPoints = 0;
    public Transform[] points = new Transform[0];
    public int speed;
    public GameObject cubo;

    public Camera gopro;
    public GameObject herramienta;
    public Animator escala;

    public GameObject burbuja;
    int contadorBurbujas;
    public LayerMask layer;
    RaycastHit ray;


    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Update is called once per frame
    private void Update()
    {
        Movimiento();
        StartCoroutine("spawnBubles");
    }

    #region Metodos
    public virtual void Movimiento()
    {
        cubo.transform.position = Vector3.MoveTowards(transform.position, points[indexWayPoints].transform.position, speed * Time.deltaTime);
        if (cubo.transform.position == points[indexWayPoints].position)
        {
            indexWayPoints++;
        }
        if (indexWayPoints == points.Length)
        {
            indexWayPoints = 0;
        }
    }

    public void Escalar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = gopro.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                escala.SetBool("Escalando", false);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = gopro.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                escala.SetBool("Escalando", true);
            }
        }
    }


    #endregion Metodos

    #region Cortinas
    IEnumerator spawnBubles()
    {

        Instantiate(burbuja);
        yield return new WaitForSeconds(5f);
        Destroy(this);
        
    }
    #endregion Cortinas

}
