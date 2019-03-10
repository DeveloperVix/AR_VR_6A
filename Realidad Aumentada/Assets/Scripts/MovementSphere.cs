using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSphere : MonoBehaviour
{
    public GameObject respawn;

    public void OnClickW()
    {
        Vector3 positionSphere = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);                                                               //Se crea un vector 3 que guardara la escala de la sphere
        transform.position = positionSphere;
    }

    public void OnClickA()
    {
        Vector3 positionSphere = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);                                                               //Se crea un vector 3 que guardara la escala de la sphere
        transform.position = positionSphere;
    }

    public void OnClickS()
    {
        Vector3 positionSphere = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);                                                               //Se crea un vector 3 que guardara la escala de la sphere
        transform.position = positionSphere;
    }

    public void OnClickD()
    {
        Vector3 positionSphere = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);                                                               //Se crea un vector 3 que guardara la escala de la sphere
        transform.position = positionSphere;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("RedCubeTag"))
        {
            transform.position = respawn.transform.position;
        }

        if (other.tag.Equals("FinishTag"))
        {
            GameController.act.Puzzle6();
        }
    }
}
