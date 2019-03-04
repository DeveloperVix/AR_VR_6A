using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;



public class AR : MonoBehaviour
{
    public Transform[] Points;
    public Camera Ar;
    public LayerMask layer;
    public GameObject cilindro;
    int currentPoint;
    public int speed;
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
            if(Physics.Raycast(Ar.ScreenPointToRay(Input.mousePosition),out hit, Mathf.Infinity, layer))
            {
                Debug.Log("OTAKUUUUUUUUUUUUUUUUUUU");
                for (int i = 0; i < Points.Length; i++)
                {
                    if (cilindro.transform.position == Points[currentPoint].position)
                    {
                        currentPoint = (currentPoint + 1) % Points.Length;
                    }
                }
            }
        }
        cilindro.transform.position = Vector3.MoveTowards(cilindro.transform.position, Points[currentPoint].position, speed * Time.deltaTime);
    }
}
