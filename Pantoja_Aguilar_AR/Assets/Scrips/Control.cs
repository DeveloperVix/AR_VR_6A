using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class Control : MonoBehaviour, ITrackableEventHandler{
    // segun la la pagina de vuforia TrackableBehaviour tenica que utilisarlo al ejecutar a la animcion por sus estados pero no entendi bien porque :V
    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status previo;
    protected TrackableBehaviour.Status nuevo;
    
    public VideoPlayer video;
    public Animator animator;
    
    void Start(){
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour){
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
    
    void ocultar(){
        animator.Play("ocultar");
    }

    void mostrar(){
        animator.Play("mostrar");
    }

    public void reproducir(){
        video.Play();
    }

    public void pausar(){
        video.Pause();
    }

    // me pedia que utilisara ese mismo TrackableBehaviour para ejecutarlas 

    public void OnTrackableStateChanged(TrackableBehaviour.Status estadoPrevio, TrackableBehaviour.Status estadoNuevo){

        previo = estadoPrevio;
        nuevo = estadoNuevo;

        if (estadoNuevo == TrackableBehaviour.Status.DETECTED || estadoNuevo == TrackableBehaviour.Status.TRACKED || estadoNuevo == TrackableBehaviour.Status.EXTENDED_TRACKED){
            video.Play();
            ocultar();
        }
        else if (estadoPrevio == TrackableBehaviour.Status.TRACKED && estadoNuevo == TrackableBehaviour.Status.NO_POSE){
            video.Stop();
            mostrar();
        }
        else{
            video.Stop();
            mostrar();
        }
    }
}