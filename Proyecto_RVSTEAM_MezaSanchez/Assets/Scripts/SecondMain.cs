using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SecondMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(vFlag);
    }


    public bool activateRot = false;
    Vector3 vFlag;
    public RotateObject RotateObjectScritpable;
    public void TRotObj(RotateObject scriptable)
    {
        if(scriptable != null && activateRot)
        {
            //transform.Rotate(scriptable.rotMovement);
            vFlag = scriptable.rotMovement;
        }
    }
    public void URotObj(RotateObject scriptable)
    {
        if (scriptable != null && activateRot)
        {
            vFlag = new Vector3(0, 0, 0);
        }
    }

    public bool activateAudio = false;
    public PlayAudio PlayAudioScriptable;
    GameObject media;
    bool parentOP = true;
    public void TPAudio(PlayAudio scriptable)
    {
        if (scriptable != null && activateAudio)
        {
            if (parentOP)
            {
                Instantiate(scriptable.audioTest, this.transform);
                //Instantiate(scriptable.flag);
                parentOP = false;
            }
            //this.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true); 

            //media = GameObject.Find(this.name + "Track");

            if(media == null)
            {
                //media = GameObject.Find(this.name + "Track");
                //media.SetActive(true);
            }
            else
            {
                media.SetActive(true);
            }
            //media.SetActive(true);
            
            // media = GameObject.FindGameObjectWithTag("Pista").GetComponent<GameObject>();
            //media.Play();
        }
    }
    public void UPAudio(PlayAudio scriptable)
    {
        if (scriptable != null && activateAudio)
        {
            //this.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            if (media == null) media = GameObject.Find(this.name + "Track");
            media.SetActive(false);
            // Destroy(GameObject.FindGameObjectWithTag("Pista"));
            // media.Pause();
        }
    }

    public bool activateParticles = false;
    public ShowParticles ShowParticlesScriptable;
    GameObject part;
    public void TParticles(ShowParticles scriptable)
    {
        if (scriptable != null && activateParticles)
        {
            part = scriptable.bubbble;
            Instantiate(part, this.transform.position, Quaternion.identity);
        }
    }
    public void UParticles(ShowParticles scriptable)
    {
        if (scriptable != null && activateParticles)
        {
            Destroy(GameObject.FindGameObjectWithTag("Bubble"));
        }
    }

    public bool activateText = false;
    public ShowText ShowTextScriptable;
    public void TSText(ShowText scriptable)
    {
        if (scriptable != null && activateText)
        {
            //scriptable.text.SetActive(true);
            Instantiate(scriptable.text,this.transform.position,Quaternion.identity);
        }
    }
    public void USText(ShowText scriptable)
    {
        if (scriptable != null && activateText)
        {
            //scriptable.text.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("TextShowing"));
        }
    }

    public bool activateColor = false;
    public ChangeColor ChangeColorScriptable;
    public void TColor(ChangeColor scriptable)
    {
        if (scriptable != null && activateColor)
        {
            MeshRenderer mesh = GetComponent<MeshRenderer>();
            mesh.material = scriptable.mat2;
        }
    }
    public void UColor(ChangeColor scriptable)
    {
        if (scriptable != null && activateColor)
        {
            MeshRenderer mesh = GetComponent<MeshRenderer>();
            mesh.material = scriptable.mat;
        }
    }

    public void ExecuteActions()
    {
        TRotObj(RotateObjectScritpable);
        TPAudio(PlayAudioScriptable);
        TParticles(ShowParticlesScriptable);
        TSText(ShowTextScriptable);
        TColor(ChangeColorScriptable);
    }

    public void StopActions()
    {
        URotObj(RotateObjectScritpable);
        UPAudio(PlayAudioScriptable);
        UParticles(ShowParticlesScriptable);
        USText(ShowTextScriptable);
        UColor(ChangeColorScriptable);
    }
}
