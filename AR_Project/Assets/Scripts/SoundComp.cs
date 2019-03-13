using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundComp : MonoBehaviour
{
    public Camera cam;
    public AudioClip[] Aclip;
    public AudioSource myAudioSource;
    string butNum;
    void Start()
    {

        myAudioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                  
            }


        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;

            if(Physics.Raycast(ray,out Hit))
            {
                butNum = Hit.transform.name;
                switch (butNum)
                {
                    case "but1":
                        myAudioSource.clip = Aclip[0];
                        myAudioSource.Play();
                        break;

                    case "but2":
                        myAudioSource.clip = Aclip[1];
                        myAudioSource.Play();
                        break;

                    case "but3":
                        myAudioSource.clip = Aclip[2];
                        myAudioSource.Play();
                        break;

                    case "but4":
                        myAudioSource.clip = Aclip[3];
                        myAudioSource.Play();
                        break;

                    case "but5":
                        myAudioSource.clip = Aclip[4];
                        myAudioSource.Play();
                        break;

                    case "but6":
                        myAudioSource.clip = Aclip[5];
                        myAudioSource.Play();
                        break;

                    case "but7":
                        myAudioSource.clip = Aclip[6];
                        myAudioSource.Play();
                        break;

                    case "but8":
                        myAudioSource.clip = Aclip[7];
                        myAudioSource.Play();
                        break;

                    case "but9":
                        myAudioSource.clip = Aclip[8];
                        myAudioSource.Play();
                        break;

                    default:
                        break;

                }
            }

        }

    }
}
