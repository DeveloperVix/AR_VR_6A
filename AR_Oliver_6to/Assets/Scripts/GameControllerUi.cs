using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerUi : MonoBehaviour
{
    private static GameControllerUi instance;

    public static GameControllerUi Instance { get { return instance; } }

    public GameObject objLoading;

    

    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        else
        {
            Debug.Log("Hay más de una instancia!!");
        }

        objLoading = GameObject.Find("Canvas/LoadingScene");

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

        while(async != null)
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
