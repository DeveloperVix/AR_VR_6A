using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAndPanelController : MonoBehaviour
{
    private static SceneAndPanelController instance;
    public static SceneAndPanelController Instance { get { return instance; } }
    public GameObject objLoading;

    public void Game()
    {
        objLoading.SetActive(true);
        StartCoroutine(LoadScene(1));
    }
    public void Menu()
    {
        objLoading.SetActive(true);
        StartCoroutine(LoadScene(0));
    }
    void Start()
    { 
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.Log("HolaQuePedoNegro");
            Destroy(gameObject);
        }
        
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable llamado!");
        SceneManager.sceneLoaded += OnSceneLoad;
    }
    private void OnDisable()
    {
        Debug.Log("Disable llamado!");
        SceneManager.sceneLoaded -= OnSceneLoad;
    }
    //Metodo Propio
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Escena Cargada");
        objLoading = GameObject.Find("Canvas/Loading");
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
        while (!async.isDone)
        {
            yield return null;
        }
    }
    #endregion

    public void ExitGame()
    {
        Application.Quit();
    }
}
