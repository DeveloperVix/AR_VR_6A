using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerUI : MonoBehaviour
{
    private static GameControllerUI instance;
    public static GameControllerUI Instance { get { return instance; } }//Acceder a todo lo que tiene este codigo
    //instance es para checar si ya existe otra instancia de la misma clase

    public GameObject objLoading;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);//que no se destruya cuando cargue una nueva escena
        }
        else
        {
            Debug.LogError("Hay mas de una instancia >:v");
        }

        objLoading = GameObject.Find("Canvas/BackgroundLoading");//ACCEDEMOS A UN HIJO
        objLoading.SetActive(false);
    }

    //REGION ES PARA ACOMODAR EL CODIGO
    #region Buttons UI

    public void LoadNewScene(int indexScene)
    {
        objLoading.SetActive(true);
        StartCoroutine(LoadScene(indexScene));
    }

    IEnumerator LoadScene(int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);//AsyncOperation es el proceso de pantalla de carga

        while(async != null)
        {   
            yield return null;
            //yield return new WaitForSeconds(5f);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    #endregion

    /*void Update()
    {
        
    }*/
}
