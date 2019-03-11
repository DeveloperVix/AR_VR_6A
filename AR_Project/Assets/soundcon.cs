using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundcon : MonoBehaviour
{
    public AudioClip[] aClips;

    public AudioSource myAudiosource;

    string btnName;
    // Start is called before the first frame update
    void Start()
    {
        myAudiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if(Physics.Raycast(ray, out Hit))
            {
                btnName = Hit.transform.name;
                switch (btnName)
                {
                    case "Button1":
                        myAudiosource.clip = aClips[0];
                        myAudiosource.Play();
                        break;
                    case "Button2":
                        myAudiosource.clip = aClips[1];
                        myAudiosource.Play();
                        break;
                    case "Button3":
                        myAudiosource.clip = aClips[2];
                        myAudiosource.Play();
                        break;
                    case "Button4":
                        myAudiosource.clip = aClips[3];
                        myAudiosource.Play();
                        break;
                    case "Button5":
                        myAudiosource.clip = aClips[4];
                        myAudiosource.Play();
                        break;
                    case "Button6":
                        myAudiosource.clip = aClips[5];
                        myAudiosource.Play();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
