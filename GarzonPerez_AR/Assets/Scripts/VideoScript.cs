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

    [Header("Animaciones de Puzzles")]
    public Animator anim;
    public Animator animButton;
    public Animator CilindroAnim;
    public Animator Rodi;

    [Header("Objetos de Puzzles")]
    public GameObject cilindro;
    public GameObject win;
    public GameObject Pelota, pelota2;
    public GameObject es;
    public GameObject es1;
    public GameObject es2;
    public GameObject Rodillo;

    [Header("Valores de Puzzles")]
    public float range = 10f;
    public int VidaCilindro1= 12;

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
                if (cilindro == true)
                {
                    VidaCilindro1 -= 4;
                    CilindroAnim.speed += 1;
                    if (VidaCilindro1 <= 0)
                    {
                        Destroy(cilindro);
                        StartCoroutine("Contador");
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit1;
            if (Physics.Raycast(ray1, out hit1))
            {
                if (Pelota == true)
                {
                    Destroy(Pelota);
                    pelota2.SetActive(true);
                    if (pelota2 == true && Pelota == null)
                    {
                        Destroy(pelota2);
                        StartCoroutine("Contador");
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit2;
            if (Physics.Raycast(ray2, out hit2))
            {
                if (es == true)
                {
                    Destroy(es);
                    es1.SetActive(true);
                    if (es1 == true && es == null)
                    {
                        Destroy(es1);
                        es2.SetActive(true);
                        if (es2 == true && es == null && es1 == null)
                        {
                            Destroy(es2);
                        }

                    }
                }
                
                if(es == null && es1 == null && es2 == null)
                {
                    StartCoroutine("Puzzle4");
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit2;
            if (Physics.Raycast(ray2, out hit2))
            {
                if(Rodillo == true)
                {
                    StartCoroutine("Rodillera");
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
    IEnumerator Contador()
    {
        win.SetActive(true);
        pelota2.SetActive(false);
        yield return new WaitForSeconds(2f);
        win.SetActive(false);
    }
    IEnumerator Puzzle4()
    {
        win.SetActive(true);
        yield return new WaitForSeconds(2f);
        win.SetActive(false);
    }
    IEnumerator Rodillera()
    {
        Rodi.SetBool("Rodilla", true);
        yield return new WaitForSeconds(2);
        win.SetActive(true);
        Destroy(Rodi);
        yield return new WaitForSeconds(2f);
        win.SetActive(false);
    }
}
