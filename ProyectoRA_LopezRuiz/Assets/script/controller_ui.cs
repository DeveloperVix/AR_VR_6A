using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller_ui : MonoBehaviour
{

    private static controller_ui instance;
    public static controller_ui Instance
    {
        get
        {
            return instance;
        }
    }

    public GameObject objLoading;


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("Hay mas de una instancia de esta clase, lo voy a destruir");
            Destroy(gameObject);
        }

        /*objLoading = GameObject.Find("Canvas/BackgroundLoadingdLoading");
        objLoading.SetActive(false);*/
    }

    void OnEnable()
    {
        Debug.LogError("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        Debug.LogError("Remuevo delegante ");
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Destroy(gameObject);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.LogError("Escena cargada");
        objLoading = GameObject.Find("Canvas/backgroundloading");
        objLoading.SetActive(false);
    }

    IEnumerator LoadScene(int indexScene)
    {

        AsyncOperation async = SceneManager.LoadSceneAsync(indexScene);

        while (async != null)
        {
            yield return null;
        }

    }

    #region Buttons //estetica de codigo, sirve para esconder las cosas

    public void LoadSceneBtn(int indexScene)
    {
        objLoading.SetActive(true);
        StartCoroutine(LoadScene(indexScene));
    }

    #endregion

}
// si los 6 puzzles se resuelven que haya hay retroalimentacion
//boton de reseteo de puzzles
//tarea_Arquitectura_Puzzle (parte1 o 2 o 3)
//Ejercicio_Puzzle