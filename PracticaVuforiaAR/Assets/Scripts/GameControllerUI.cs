using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameControllerUI : MonoBehaviour
{
    private static GameControllerUI instance;
    public static GameControllerUI Instance
    {
        get
        {
            return instance;
        }
    }

    public GameObject objLoading;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)                                                             //la estancia es nula
        {
            instance = this;                                                             //instancia igual a este
            DontDestroyOnLoad(this);                                                     //no destruye el componenete que tiene
        }
        else
        {
            Debug.LogError("Hay mas de una instancia");                                  //si hay mas de una isntancia
            Destroy(gameObject);
        }

    }

    void OnEnable()
    {
        Debug.LogError("OnEnable llamado");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        Debug.LogError("OnDisiable llamado");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //Metodo Propio
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.LogError("Escena cargada");
        objLoading = GameObject.Find("Canvas/BackgroundLoading");                        //busca la pantalla de loading y la desactiva
        objLoading.SetActive(false);
    }

    #region Buttons UI

    public void LoadNewScene(int indexScene)                                         //pediremos que escena quiere que cargue
    {
        objLoading.SetActive(true);
        StartCoroutine(LoadScene(indexScene));                                       //nos pide un parametro entero
    }

    IEnumerator LoadScene(int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);

        while (!async.isDone)                                                        //mientras la operacion asincronica no este terminada retornara nulo
        {
            
            yield return null;                                                       //aqui se coloca el tiempo que se desea que tarde 
        }
    }

    public void BtnExit()
    {
        Application.Quit();
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
}
