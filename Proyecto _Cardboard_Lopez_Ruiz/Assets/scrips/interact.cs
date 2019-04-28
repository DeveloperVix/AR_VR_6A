using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface interact
{
    //Interfaz que el script que controle las interacciones, debera implementar
    void LookOnMe();    //Cuando el jugador ve el objeto
    void NoLookOnMe();  //Cuando el jugador deja de ver el objeto
}
