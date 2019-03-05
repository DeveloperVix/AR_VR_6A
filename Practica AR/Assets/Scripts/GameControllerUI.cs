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
            Destroy(gameObject);//destruye esto
        }

        /*objLoading = GameObject.Find("Canvas/BackgroundLoading");//ACCEDEMOS A UN HIJO
        objLoading.SetActive(false);*/
    }

    private void OnEnable()//Se madna llamar cuando inicia el comportamiento del objeto 
    {
        Debug.LogError("OnEnable llamdo!");
        SceneManager.sceneLoaded += OnSceneLoaded;//Le estamos añadiendo el metodo propio que creamos con el +=
    }

    private void OnDisable()//Cunado ya no esta activado el objeto
    {
        Debug.LogError("OnDisable llamado!");
        SceneManager.sceneLoaded -= OnSceneLoaded;//Le quitamos el metodo propio con -=
    }

    //Metodo popio
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)//Es para saber cuando esta cargada la escena
    {  
        Debug.Log("Escena cargada");
        objLoading = GameObject.Find("Canvas/BackgroundLoading");
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

        while(!async.isDone)//Mientras la operacion asincronica no este terminada va a retornar nulo
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
}
