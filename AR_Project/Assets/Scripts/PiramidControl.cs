using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PiramidControl : MonoBehaviour
{
    public static int slotsOccupied;

    [SerializeField]
    private Transform[] rings;

    [SerializeField]
    private GameObject winSign;

    [SerializeField]
    private GameObject wrongSign;

    // Start is called before the first frame update
    void Start()
    {
        Drag.PuzzleDone += CheckResults;
        slotsOccupied = 0;
        winSign.SetActive(false);
        wrongSign.SetActive(false);
        
    }

    public void CheckResults()
    {
        if(rings[0].position.y == 0.303f &&
            rings[1].position.y == 0.199f &&
            rings[2].position.y == 0.095f &&
            rings[3].position.y == -0.006f)
        {
            winSign.SetActive(true);
            Invoke("ReloadGame", 2f);
        }
        else
        {
            wrongSign.SetActive(true);
            Invoke("ReloadGame", 1f);
        }
    }

    private void ReloadGame()
    {
        Drag.PuzzleDone -= CheckResults;
        SceneManager.LoadScene("Scene_AR");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
