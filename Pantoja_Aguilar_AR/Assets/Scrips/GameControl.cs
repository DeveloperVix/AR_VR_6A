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
        else{
	 Destroy(gameObject);
	}
    }
	
   /* private void OnEnable() {

        objLoading=GameObject.Find("Canvas/BachgrunLoading");
    }*/
	 void OnEnable() {

        SceneManager.sceneLoaded+=OnSceneLoaded;
    }
     void OnDisable() {
	SceneManager.sceneLoaded-=OnSceneLoaded;        
    }

	void OnSceneLoaded(Scene scen, LoadSceneMode mode) {
	objLoading = GameObject.Find("Canvas/BachgrunLoading");
        objLoading.SetActive(false);
	
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

        while (!async.isDone) {
            yield return null;
        }
    }
    public void BtnExit(int indeexScene)
    {
        Application.Quit();
    }


}
