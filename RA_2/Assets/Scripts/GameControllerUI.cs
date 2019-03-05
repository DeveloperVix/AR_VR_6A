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
            Destroy(gameObject);
        }
    }

    /*private void Enable()
    {
        //objLoading = GameObject.Find("Canvas/BackgroundLoading");
        Debug.Log("Estoy Activo");
    }*/

    void OnEnable()
    {
        Debug.LogError("OnEnable llamado");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        Debug.LogError("OnDisable llamado");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //metodo propio
    void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        Debug.LogError("Escena cargada");
        objLoading = GameObject.Find("Canvas/BackgroundLoading");
        objLoading.SetActive(false);
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

        while (!async.isDone)//mientras la operacion asincronica no este terminada retornada null
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
