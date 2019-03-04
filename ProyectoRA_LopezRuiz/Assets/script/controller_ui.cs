using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller_ui : MonoBehaviour
{

    private static controller_ui instace;
    public static controller_ui Instace {get { return instace; } }

    public GameObject objLoading;

    void Start()
    {
        //objLoading = GameObject.Find("Canvas/back");
        

        objLoading.SetActive(false);
        if (instace == null)
        {
            instace = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.LogError("hay mas de una instancial!!");
        }


    }

   private void OnEnable()
    {
        objLoading = GameObject.Find("Canvas/back");
        objLoading.SetActive(false);
    }

    #region buttons UI

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
