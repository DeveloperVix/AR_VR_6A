using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControll : MonoBehaviour {

    public GameObject objLoad;

    private static GameControll instance;

    public static GameControll Instance { get { return instance; } }

    [SerializeField]
    private Transform[] pictures;

    [SerializeField]
    private GameObject winText;

    public static bool youWin;


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
            Debug.Log("Too Many Instances");
            Destroy(gameObject);
        }
        winText.SetActive(false);
        youWin = false;

    }

    void OnEnable()
    {
        Debug.LogError("OnEnable is called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        Debug.LogError("OnDisablee is called");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // metodo propio
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.LogError("Scene Loaded");
        objLoad = GameObject.Find("Canvas/BackgroundLoading");
        objLoad.SetActive(false);
    }

    #region Buttons UI

    public void LoadNewScene(int indexScene)
    {
        objLoad.SetActive(true);
        StartCoroutine(LoadScene(indexScene));
    }

    IEnumerator LoadScene(int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);

        while (async.isDone) // mientrtas la escena este cargando, retorna nulo
        {
            yield return null;
        }
    }

    #endregion

    public void ExitButt()
    {
        Application.Quit();
    }

    void Update()
    {
        if (pictures[0].rotation.z == 0 &&
           pictures[1].rotation.z == 0 &&
           pictures[2].rotation.z == 0 &&
           pictures[3].rotation.z == 0 &&
           pictures[4].rotation.z == 0 &&
           pictures[5].rotation.z == 0)
        {
            youWin = true;
            winText.SetActive(true);
        }
    }

}
