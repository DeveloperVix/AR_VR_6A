using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonPlay()
    {
        StartCoroutine(LoadScene("PuzzleGame"));
    }

    IEnumerator LoadScene(string scene)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(scene);
        yield return load.isDone;
        load.allowSceneActivation = true;
    }
}
