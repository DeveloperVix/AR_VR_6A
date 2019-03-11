using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;



public class AR : MonoBehaviour
{


    public Camera Ar;
    public LayerMask layer;
    Vector3 giro;
    public static int contGanar1;
    public static int contGanar2;
    public GameObject ganar;

    // Start is called before the first frame update
    void Start()
    {
        contGanar1 = 0;
        contGanar2 = 0;
        ganar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(Ar.ScreenPointToRay(Input.mousePosition),out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.layer == 9)
                {
                    hit.collider.gameObject.GetComponent<Mover>().MoverFig();
                }
                if (hit.collider.gameObject.layer == 10)
                {
                    hit.collider.gameObject.GetComponent<Rotar>().Datos();
                    hit.collider.gameObject.GetComponent<Rotar>().rotBool = true;
                    hit.collider.gameObject.GetComponent<Rotar>().estado += 1;
                    Debug.Log("Girartrue");
                }
            }
          
        }
        if(contGanar1 == 6 && contGanar2 == 22)
        {
            ganar.SetActive(true);
        }
    }


    IEnumerator gana()
    {

        yield return new WaitForSeconds(3);
        GameControllerUI.Instance.LoadNewScene(1);
    }
}
