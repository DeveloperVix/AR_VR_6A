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
        }


        objLoading = GameObject.Find("Canvas/LoadingMenu");
        objLoading.SetActive(false);
    }

    private void OnEnable()
    {
        objLoading = GameObject.Find("Canvas/LoadingScene");
        Debug.Log("Está Activo");
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

        while (async != null)
        {
            yield return null;
        }
    }


    #endregion

}