using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerUI : MonoBehaviour
{

    private static GameControllerUI instance;

    public GameObject objLoading;

    public static GameControllerUI Instance { get { return instance; } }


    // Start is called before the first frame update
    void Start()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            Debug.LogError("Hay mas de una instancia");
            Destroy(gameObject);
        }

        
    }

    private void OnEnable()
    {
        Debug.LogError("OnEnable llamado");
        SceneManager.sceneLoaded += OnSceneLoaded;
        //objLoading = GameObject.Find("Canvas/backgroundLoading");
        //Debug.Log("Estoy activo");
    }

    void OnDisable()
    {
        Debug.LogError("OnDisable llamado");
        SceneManager.sceneLoaded -= OnSceneLoaded;
           
    }
    //metodo propio
    void OnSceneLoaded(Scene scene , LoadSceneMode mode)
    {
        Debug.LogError("Escena cargada");
        

        objLoading = GameObject.Find("Canvas/backgroundloading");
        objLoading.SetActive(false);
    }

    #region Buttons UI
    public void LoadNewScene(int indexScene)
    {
        objLoading.SetActive(true);
        StartCoroutine(LoadScene(indexScene));
    }

    public void btnexit()
    {
        Application.Quit();
    }

    IEnumerator LoadScene(int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);

        while (async.isDone)
        {
            yield return null;
        }
    }
    #endregion

}
