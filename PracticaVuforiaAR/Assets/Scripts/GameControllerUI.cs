using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameControllerUI : MonoBehaviour
{
    private static GameControllerUI instance;
    public static GameControllerUI Instance
    {
        get
        {
            return instance;
        }
    }

    public GameObject objLoading;

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
            Debug.LogError("Hay mas de una instancia");
        }

        objLoading = GameObject.Find("Canvas/BackgroundLoading");

        objLoading.SetActive(false);
    }

    private void OnEnable()
    {
        objLoading = GameObject.Find("Canvas/BackgrounLoading");
        Debug.Log("Im Here Nigga");
    }

    #region Buttons UI

    public void LoadNewScene(int indexScene)                    //pediremos que escena quiere que cargue
    {
        objLoading.SetActive(true);
        StartCoroutine(LoadScene(indexScene));                    //cambia de escena
    }

    IEnumerator LoadScene(int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);

        while (async != null)                                   //se indica la cantidad de tiempo de espera para pasar de pantalla
        {
            
            yield return null;                                 //aqui se coloca el tiempo que se desea que tarde 
        }
    }

    public void BtnExit()
    {
        Application.Quit();
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
}
