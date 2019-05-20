using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationsDoors : MonoBehaviour
{
    public Transform OPEN1;
    public Transform OPEN2;
    public Transform thisDoor1;
    public Transform thisDoor2;

    public Animation animacionPuerta1OPEN;
    public Animation animacionPuerta2OPEN;
    public Animation animacionPuerta1CLOSE;
    public Animation animacionPuerta2CLOSE;
    public bool mirando = false;

    public void Start()
    {
        OPEN1 = GetComponent<Transform>();
        OPEN2 = GetComponent<Transform>();
        thisDoor1 = GetComponent<Transform>();
        thisDoor2 = GetComponent<Transform>();

        animacionPuerta1OPEN = GameObject.FindGameObjectWithTag("DOOR1").GetComponent<Animation>();
        animacionPuerta2OPEN = GetComponent<Animation>();
        animacionPuerta1CLOSE = GetComponent<Animation>();
        animacionPuerta2CLOSE = GetComponent<Animation>();
    }

    public void Update()
    {
        if (mirando == true)
        {
            Debug.Log("MIRANDO");
            //thisDoor1.transform.position.Set(OPEN1.position.x, OPEN1.position.y, OPEN1.position.z);
            //thisDoor2.transform.position.Set(OPEN2.position.x, OPEN2.position.y, OPEN2.position.z);
            animacionPuerta1OPEN.Play();
            //animacionPuerta2OPEN.Play();
            Debug.Log("sigo mirando xd");
        }

        if (mirando == false)
        {
           /* animacionPuerta1OPEN.Stop();
            animacionPuerta2OPEN.Stop();
            animacionPuerta1CLOSE.Play();
            animacionPuerta2CLOSE.Play();*/
        }
    }

    public void OnPointerEnter()
    {
        Debug.Log("Abriendo");
        mirando = true;
    }

    public void OnPointerExit()
    {
        Debug.Log("Cerrando");
        mirando = false;
    }
}
