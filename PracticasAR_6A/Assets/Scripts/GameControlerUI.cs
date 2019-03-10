﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//libreria

public class GameControlerUI : MonoBehaviour
{
    private static GameControlerUI instance;//estara checando si ya existe otra instancia de esta clase, si ya existe, la eliminara
    public static GameControlerUI Instance { get { return instance; } }//variable encapsulada de instance, nos permitira acceder a todo lo que tengamos en nuestro script y sea publico

    public GameObject objLoading;//muestra interfaz
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)//si es nula
        {
            instance = this;//garantizamos que solo exista una instancia y no la destruya cuando carga una escena
            DontDestroyOnLoad(this);//no destruyas esta instancia cuando hagamos cambio de escena
        }
        else//si existe una instancia
        {
            Debug.LogError("Hay mas de una instancia!!");
        }

        
    
    }

    private void OnEnable()//si es verdadero est emetodo se manda a llamar
    {
        Debug.LogError("OnEnable llamado");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        Debug.LogError("OnDisable llamado");
        SceneManager.sceneLoaded -= OnSceneLoaded;//
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)//metodo propio
    {
        Debug.Log("Escena cargada");//
        objLoading = GameObject.Find("Canvas/BackgroundLoading");
        objLoading.SetActive(false);//desactivar la escena
    }

    #region Buttons UI
    public void LoadNewScene(int indexScene)//codigo para cargar las escenas
    {
        objLoading.SetActive(true);//activa la escena
        StartCoroutine(LoadScene(indexScene));//inicia la corrutina
    }

    public void BtnExit()//salir del programa
    {
        Application.Quit();
    }
    IEnumerator LoadScene(int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);//Async... es lo que hace que se cargue la escene asincronicamente.
        //el index detecta automaticamente el numero de escena y la carga

        while (!async.isDone)//este while lo podemos omitir, reaalmente nos sirve para pdoer controlar el tiempo de carga.
                             //mientras la operacion asincroncia no este terminada, va a devolver nulo
        {
            yield return null;//si quisieramos que tardar tiempo extra de lo que le lleva normalmente, podemos ponerlo aqui
        }
    }

    #endregion
}