using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SecuenseController : MonoBehaviour
{

    public List<GameObject> circles;

    public Camera thisCamera;
    public GameObject sphere;
    public int buttonNumberOrder;
    public Material wrongChoice;
    public Material correctOrder;
    public Material defaultMaterial;

    private bool flag = false;
    private bool onTrackStay = false;

    [Header("Material de animacion boton")]
    public GameObject button;

    void Start()
    {
    }

    void Update()
    {
        
    }


    public void CheckOrder(int index)
    {
        Debug.Log("Checking order");

        for (int i = 0; i < index; i++)
        {
            if (!circles[i].gameObject.activeSelf)
            {
                StartCoroutine(WrongOrder());
                break;
            }
            else
            {
                if(i + 1 == circles.Count)
                {
                    Debug.Log("Has ganado!!!");
                    foreach (GameObject x in circles)
                    {
                        x.GetComponent<MeshRenderer>().material = correctOrder;
                    }
                    flag = true;
                }
            }
        }
    }

    IEnumerator WrongOrder()
    {
        foreach (GameObject i in circles)
        {
            i.GetComponent<MeshRenderer>().material = wrongChoice;
        }
        yield return new WaitForSeconds(2f);
        foreach (GameObject i in circles)
        {
            i.gameObject.SetActive(false);
            i.GetComponent<MeshRenderer>().material = defaultMaterial;
        }
    }

    public void ChangeRender()
    {
        StartCoroutine(change());
    }

    IEnumerator change()
    {
       button.SetActive(false);
       yield return new WaitForSeconds(2f);
       button.SetActive(true);
       StartCoroutine(change());  
    }
}
