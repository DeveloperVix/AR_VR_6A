using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller: MonoBehaviour
{
    public GameObject objLoading;

    private static Controller instance;

    public static Controller Instance { get { return instance; } }

    void Start()
    {
        if (instance == null)
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
        SceneManager.sceneLoaded += onSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= onSceneLoaded;
    }

    //propio
    void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        objLoading = GameObject.Find("Canvas/LoadingMenu");
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

        while (!async.isDone)
        {
            yield return null;
        }
    }
    /*public void Exit()
    {
        Application.Quit();
    }*/

    #endregion

}