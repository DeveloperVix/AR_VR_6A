using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameControlUI : MonoBehaviour
{
    private static GameControlUI instance;
    public static GameControlUI Instance { get { return instance; } }

    public GameObject objLoading;

    // Start is called before the first frame update
    void Start()
    {
        if (instance = null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.LogError("Hay mas de una instancia");
            Destroy(gameObject);
        }
        
    }

    private void OnEnable()
    {
        Debug.LogError("OnEnable llamado");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnDisable()
    {
        Debug.LogError("OnDisable llamado");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //metodo propio
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.LogError("Esene Cargada");
      
        objLoading = GameObject.Find("Canvas/Loading");
        objLoading.SetActive(false);
    }

    #region Buttons UI

    public void LoadNewScene(int indexScene)
    {

        objLoading.SetActive(true);
        StartCoroutine(LoadScene(indexScene));
    }


    IEnumerator LoadScene(int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);

        while(!async.isDone)
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
