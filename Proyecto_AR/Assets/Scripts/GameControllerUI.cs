using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameControllerUI : MonoBehaviour
{
    public GameObject objLoading;

    private static GameControllerUI instance;

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
        }

        objLoading = GameObject.Find("Canvas/BackgroundLoading");

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

        while (async != null)
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
