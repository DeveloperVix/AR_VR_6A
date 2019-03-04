using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class VideoScript : MonoBehaviour
{
    DefaultTrackableEventHandler Statusimg;
    public VideoPlayer VideoPlayer;
    bool OnPlays = false;
    public float range = 10f;
    public Animator anim;
    public Animator animButton;
    public GameObject cilindro;
    public GameObject win;

    void Start()
    {
        Statusimg = GetComponent<DefaultTrackableEventHandler>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(cilindro == true)
                {
                    Destroy(cilindro);
                    win.SetActive(true);
                }
            }
        }
        if (Statusimg.isDetected && OnPlays){
            playButton();
            anim.SetBool("Inicio", true);        
            animButton.SetBool("InicioButton", true);

        }
        else if (!Statusimg.isDetected)
        {
            pauseButton();
            anim.SetBool("Inicio", false);
            animButton.SetBool("InicioButton", false);
        }
    }
    public void playButton()
    {
        VideoPlayer.Play();
        OnPlays = false;
    }
    public void pauseButton()
    {
        VideoPlayer.Pause();
        OnPlays = true;
    }
}
