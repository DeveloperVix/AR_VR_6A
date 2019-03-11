using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameControllerUI : MonoBehaviour
{

    private static GameControllerUI instance;
    public static GameControllerUI Instance { get { return instance; } }


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
            Debug.Log("Hay más de un instancia!!");
            Destroy(gameObject);
        }
    }


    /* public void create()
     {
         objLoading = GameObject.Find("Canvas/BackgroundLoading");
         objLoading.SetActive(false);
     }*/

    private void OnEnable()
    {
        Debug.LogError("OnEnable llamado!");
        SceneManager.sceneLoaded += onSceneLoaded;  //añadir el metodo propio recbiendo desde el metodo propio una esena y un
    }

    private void OnDisable()
    {
        Debug.LogError("OnDisable llamado!");
        SceneManager.sceneLoaded -= onSceneLoaded;  //borrar la reinscripcion en el metodo
    }
      //Metodo propio
    void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.LogError("Escena cargada");
        objLoading = GameObject.Find("Canvas/BackgroundLoading");
        objLoading.SetActive(false);
    }



    #region Buttons UI

    public void LoadNewScene(int indexScene)
    {
        objLoading.SetActive(true);
        StartCoroutine(LoadScene(indexScene));
    }

    public void ex()
    {
        Application.Quit();
    }


    IEnumerator LoadScene(int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        while(!async.isDone) // mientras la carga asincronica no esté completa vas a retornar nulo
        {
            yield return null;
        }
    }

    #endregion
}