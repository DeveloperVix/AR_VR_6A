using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameControllerUI : MonoBehaviour
{
    public GameObject objLoading;
    

    private static GameControllerUI instance;    //Herramientas de Singleton que te permite instanciar este script en otros scripts

    public static GameControllerUI Instance { get { return instance; } }


    // Start is called before the first frame update
    void Start()
    {
        

        if ( instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.LogError("Hay mas de una instancia!");
            Destroy(gameObject);
        }

        
    }

    
    void OnEnable()
    {
        Debug.LogError("OnEnable llamado!");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        Debug.LogError("OnDisable llamado!");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    //Metodo propio
    void OnSceneLoaded( Scene scene, LoadSceneMode mode)
    {
        Debug.LogError("Escena cargada");
        objLoading = GameObject.Find("Canvas/BackgroundLoading");
        objLoading.SetActive(false);
        GameObject Capsule = GameObject.Find("MultiTarget/ChildTargets/PKMNCUBE.Left/Capsule");
    }

    #region Buttons UI

    public void LoadNewScene(int indexScene)
    {
        
        objLoading.SetActive(true);
        StartCoroutine(LoadScene(indexScene));
    }

    IEnumerator LoadScene(int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);    //Aquí se crea una operacion asincronica que cargará la siguiente escena 

        while (!async.isDone)     //Mientras la AsyncOperation no este terminada regresa nulo
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
