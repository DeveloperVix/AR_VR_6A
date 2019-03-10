using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private static UIController instace;
    public static UIController Instace { get { return instace; } }

    public GameObject objLoading;

    void Start()
    {
        /*if (instace == null)
        {
            instace = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.LogError("hay mas de una instancial!!");
        }*/

        objLoading = GameObject.Find("Canvas/LoadingPanel");
        objLoading.SetActive(false);
    }

    private void OnEnable()
    {
        objLoading = GameObject.Find("Canvas/LoadingPanel");
    }

    #region Buttons

    public void LoadSceneButton(int indexScene)
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

    public void Exit()
    {
        Application.Quit();
    }

    #endregion
}
