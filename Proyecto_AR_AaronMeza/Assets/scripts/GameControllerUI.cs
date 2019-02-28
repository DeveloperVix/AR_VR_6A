using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameControllerUI : MonoBehaviour
{

    private static GameControllerUI instance;

    public GameObject objLoanding;

    public static GameControllerUI Instance { get { return instance; } }






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
        }

        objLoanding = GameObject.Find("Canvas/BackgroundLoading");
        objLoanding.SetActive(false);
    }



    



    #region Buttons UI

    public void LoadNewScene(int indexScene)
    {
        objLoanding.SetActive(true);
        StartCoroutine(LoadScene(indexScene));
    }

    public void ex()
    {
        Application.Quit();
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