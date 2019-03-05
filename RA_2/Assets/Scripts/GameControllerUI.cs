using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerUI : MonoBehaviour
{
    private static GameControllerUI instance;

    public GameObject objLoading;

    public static GameControllerUI Instance { get { return instance; } }


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.LogError("Hay más de una instancia!");
        }
        objLoading = GameObject.Find("Canvas/BackgroundLoading");
        objLoading.SetActive(false);
    }

    private void OnEnable()
    {
        objLoading = GameObject.Find("Canvas/BackgroundLoading");
        Debug.Log("Estoy Activo");
    }

    #region Buttons UI

    public void LoadNewScene(int indexScene)
    {
        objLoading.SetActive(true);
        StartCoroutine(LoadScene(indexScene));//cargar la escena de forma asincronica
    }

    IEnumerator LoadScene(int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);////cargar la escena de forma asincronica

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
