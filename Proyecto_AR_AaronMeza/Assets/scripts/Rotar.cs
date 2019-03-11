using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    public bool rotX;
    public bool rotY;
    public bool rotZ;
    public int rotation = 90;
    public float speed;
    public bool rotBool;
    public float rotarVar;
    public int estado;
    public float rotestado;
    public int contador;
    bool contar;
    // Start is called before the first frame update
    void Start()
    {
        rotBool = true;
        contar = true;
        rotarVar = 0;
        int ram = Random.Range(0, 3);
        estado = ram;
        contador = ram;
    }
    private void Update()
    {
        if (contador>=0)
        {
            contar = true;
        }
        if(contador<0)
        {
            contar = false;
        }

        rotar();
        if (estado == 0)
        {
            AR.contGanar2 += 1;
        }
        else if (estado != 0)
        {
            AR.contGanar2 -= 1;
        }
    }
    public void Datos()
    {
        rotarVar += rotation;
    }



    public void rotar()
    {
        if (contar)
        {
            rotBool = true;
        }
        if (rotBool)
        {
            if (rotX)
            {
                if (gameObject.transform.localEulerAngles.x <= rotarVar && estado == 1)
                {
                    gameObject.transform.Rotate(speed * Time.deltaTime, 0, 0);
                    Debug.Log("rotando en X");
                }
                if (gameObject.transform.localEulerAngles.x <= rotarVar && estado == 2)
                {
                    gameObject.transform.Rotate(speed * Time.deltaTime, 0, 0);
                    Debug.Log("rotando en X");
                }
                if (gameObject.transform.localEulerAngles.x <= rotarVar && estado == 3)
                {
                    gameObject.transform.Rotate(speed * Time.deltaTime, 0, 0);
                    Debug.Log("rotando en X");
                }
                
                if (gameObject.transform.localEulerAngles.x > rotarVar)
                {
                    rotBool = false;
                    contador -= 1;
                }

                rotestado = transform.localEulerAngles.x;
            }
            if (rotY)
            {
                if (gameObject.transform.localEulerAngles.y <= rotarVar && estado == 1)
                {
                    gameObject.transform.Rotate(0, speed * Time.deltaTime, 0);
                    Debug.Log("rotando en Y");
                }
                if (gameObject.transform.localEulerAngles.y <= rotarVar && estado == 2)
                {
                    gameObject.transform.Rotate(0, speed * Time.deltaTime, 0);
                    Debug.Log("rotando en Y");
                }
                if (gameObject.transform.localEulerAngles.y <= rotarVar && estado == 3)
                {
                    gameObject.transform.Rotate(0, speed * Time.deltaTime, 0);
                    Debug.Log("rotando en Y");
                }

                if (gameObject.transform.localEulerAngles.y > rotarVar)
                {
                    rotBool = false;
                    contador -= 1;
                }
                rotestado = transform.localEulerAngles.y;
            }
            if (rotZ)
            {
                if (gameObject.transform.localEulerAngles.z <= rotarVar && estado == 1)
                {
                    gameObject.transform.Rotate(0, 0, speed * Time.deltaTime);
                    Debug.Log("rotando en Z");
                }
                if (gameObject.transform.localEulerAngles.z <= rotarVar && estado == 2)
                {
                    gameObject.transform.Rotate(0, 0, speed * Time.deltaTime);
                    Debug.Log("rotando en Z");
                }
                if (gameObject.transform.localEulerAngles.z <= rotarVar && estado == 3)
                {
                    gameObject.transform.Rotate(0, 0, speed * Time.deltaTime);
                    Debug.Log("rotando en Z");
                }

                if (gameObject.transform.localEulerAngles.z > rotarVar)
                {
                    rotBool = false;
                    contador -= 1;
                }

                rotestado = transform.localEulerAngles.z;
            }

            if (rotarVar >= 360 && estado >= 4)
            {
                rotarVar = 0;
                estado = 0;
            }
        }
        if (rotarVar == 0 && estado == 0 && gameObject.transform.localEulerAngles.x <= 360f && gameObject.transform.localEulerAngles.x >= 270f)
        {
            gameObject.transform.Rotate(speed * Time.deltaTime, 0, 0);
            Debug.Log("rotando en X");
        }
        if (rotarVar == 0 && estado == 0 && gameObject.transform.localEulerAngles.y <= 360f && gameObject.transform.localEulerAngles.y >= 270f)
        {
            gameObject.transform.Rotate(0, speed * Time.deltaTime, 0);
            Debug.Log("rotando en Y");
        }
        if (rotarVar == 0 && estado == 0 && transform.localEulerAngles.z <= 360f && gameObject.transform.localEulerAngles.z >= 270f)
        {
            gameObject.transform.Rotate(0, 0, speed * Time.deltaTime);
            Debug.Log("rotando en Z");
        }
        if (estado == 0)
        {
            rotarVar = 0;
        }
        if (estado == 1)
        {
            rotarVar = 90;
        }
        if (estado == 2)
        {
            rotarVar = 180;
        }
        if (estado == 3)
        {
            rotarVar = 270;
        }
    }
}
