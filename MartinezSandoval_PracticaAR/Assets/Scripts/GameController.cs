using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController act;

    // Use this for initialization
    void Start()
    {
        if (act != null)
        {
            Destroy(gameObject);
        }

        act = this;
        DontDestroyOnLoad(this);


    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnEnable()
    {
        Debug.LogError("Un saludote desde OnEnable()");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        Debug.LogError("Un saludote desde OnDisable()");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //Metodo propio
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.LogError("Escena cargada");
    }

    #region Buttons UI

    public void ButtonPlay()
    {
        LoadNewScene("PuzzleGame");
    }

    public void LoadNewScene(string scene)
    {
        StartCoroutine(LoadScene(scene));
    }

    IEnumerator LoadScene(string scene)
    {                               
        AsyncOperation load = SceneManager.LoadSceneAsync(scene);
        yield return load.isDone;
        load.allowSceneActivation = true;
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    #endregion
}
