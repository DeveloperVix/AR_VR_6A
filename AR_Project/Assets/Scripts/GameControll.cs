using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class GameControll : MonoBehaviour {

    public GameObject objLoad;

    private static GameControll instance;

    public static GameControll Instance { get { return instance; } }


    // mask puzzle
    [SerializeField]
    private Transform[] Imgs;

    [SerializeField]
    private GameObject winText;

    public static bool youWin;
    //navmesh mini game

    public Camera cam;
    public NavMeshAgent agnt;


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

    void Update()
    {
        //maskpuzzle array
        if (Imgs[0].rotation.z == 0 &&
           Imgs[1].rotation.z == 0 &&
           Imgs[2].rotation.z == 0 &&
           Imgs[3].rotation.z == 0 &&
           Imgs[4].rotation.z == 0 &&
           Imgs[5].rotation.z == 0)
        {
            youWin = true;
            winText.SetActive(true);
        }

        //navmesh mini game mouse
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
                {
                agnt.SetDestination(hit.point);
            }
        }

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

    // own method
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

}
