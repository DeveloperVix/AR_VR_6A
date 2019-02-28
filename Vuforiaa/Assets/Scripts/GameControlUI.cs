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
        }

        objLoading = GameObject.Find("Canvas/Loading");
        objLoading.SetActive(false);
    }

    private void OnEnable()
    {
        objLoading = GameObject.Find("Canvas/Loading");
        Debug.Log("Estoy Activo");
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
    #endregion
}
