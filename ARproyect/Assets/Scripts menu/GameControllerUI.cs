using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerUI : MonoBehaviour
{

    private static GameControllerUI instance;
    public static GameControllerUI Instance { get { return instance; } }

    public GameObject objLoading;
    

    // Start is called before the first frame update
    void Start()
    {

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.LogError("Hay mas de una instancia!!!!!!!!!!!!!!!!!!!!!!! xdxd");
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        Debug.LogError("OnEnable llamado!");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        Debug.LogError("OnDisable llamado!");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    //metodo propio
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Escena cargada");
        objLoading = GameObject.Find("Canvas/BackGroundLoading");
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

    #endregion

    public void exit()
    {
        Application.Quit();
    }
}
