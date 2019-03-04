using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class GameController : MonoBehaviour
{


    public GameObject img;
    public VideoPlayer video;
    DefaultTrackableEventHandler script;
    public Button play;
    public Button pause;
    // Start is called before the first frame update
    void Start()
    {
        script = img.GetComponent<DefaultTrackableEventHandler>();
    }

    // Update is called once per frame
    void Update()
    {

        if (script.isDetected)
        {
            play.GetComponent<Animator>().Play("play");
            pause.GetComponent<Animator>().Play("pause");
        }
        else if (!script.isDetected)
        {
            play.GetComponent<Animator>().Play("playSalida");
            pause.GetComponent<Animator>().Play("pauseSAlir");
        }


    }



    public void playV()
    {
        video.Play();
    }

    public void stopV()
    {
        video.Pause();
    }

    private void OnEnable()
    {
        GameObject.Find("GameControllerUI").GetComponent<GameControllerUI>().create();
    }
    public void salir(int scene)
    {
        GameObject.Find("GameControllerUI").GetComponent<GameControllerUI>().LoadNewScene(scene);
    }
}
