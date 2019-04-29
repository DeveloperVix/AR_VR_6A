using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cube", menuName = "Cube")]
public class CubeScript : ScriptableObject
{
   

    public string text;
    public Material material1, Matrial2;
    public ParticleSystem particles;
    public int rotationX;
    public int rotationY;
    public GameObject gameObject;

   

}
