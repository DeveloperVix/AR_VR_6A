using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller_ui : MonoBehaviour
{

    private static controller_ui instace;
    public static controller_ui Instace { get { return instace; } }

    public GameObject objLoading;

    void Start()
    {
        //objLoading = GameObject.Find("Canvas/back");


        objLoading.SetActive(false);
        if (instace == null)
        {
            instace = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.LogError("hay mas de una instancial!!");
            Destroy(gameObject);
        }


    }

    //private void OnEnable()
    // {
    //     objLoading = GameObject.Find("Canvas/back");
    //     objLoading.SetActive(false);
    // }

    private void OnEnable()
    {
        Debug.LogError("OnEnable llamado!");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        Debug.LogError("OnDisable llamado!");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //metodo
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.LogError("Escena cargada");
        objLoading = GameObject.Find("Canvas/back");
        objLoading.SetActive(false);
    }

    #region buttons UI

    public void LoadNewScene(int indexScene)
    {
        objLoading.SetActive(true);
        StartCoroutine(LoadScene(indexScene));
    }


    IEnumerator LoadScene(int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        while (!async.isDone)//mientras no este cargada la escena va regresar nulo
        {
            yield return null;
        }
    }

    public void BtnExit()
    {
        Application.Quit();
    }

    #endregion

}
// si los 6 puzzles se resuelven que haya hay retroalimentacion
//boton de reseteo de puzzles
//tarea_Arquitectura_Puzzle (parte1 o 2 o 3)
//Ejercicio_Puzzle