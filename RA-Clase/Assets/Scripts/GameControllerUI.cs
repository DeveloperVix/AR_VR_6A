using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerUI : MonoBehaviour
{
    private static GameControllerUI instance;

    public static GameControllerUI Instance { get { return Instance; }  }

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
            Debug.LogError("Hay mas de una isntancia!!");
        }


        objLoading = GameObject.Find("Canvas/BackgroundLoading");
        objLoading.SetActive(false);
    }


    private void OnEnable()
    {
        objLoading = GameObject.Find("Canvas/BackgroundLoading");
        
        Debug.Log("Estoy activo");
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
