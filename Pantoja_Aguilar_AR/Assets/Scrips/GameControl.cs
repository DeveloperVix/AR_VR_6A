using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    private static GameControl instance;
    public static GameControl Instance { get { return instance; } }

    public GameObject objLoading;



    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this);
        }
        objLoading = GameObject.Find("Canvas/BachgrunLoading");
        objLoading.SetActive(false);
    }
    
    private void OnEnable() {

        objLoading=GameObject.Find("Canvas/BachgrunLoading");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNewScene(int indeexScene)
    {
        objLoading.SetActive(true);
        StartCoroutine(LoadScene(indeexScene));
    }
    IEnumerator LoadScene(int index) {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);

        while (async != null) {
            yield return null;
        }
    }
    public void BtnExit(int indeexScene)
    {
        Application.Quit();
    }


}
