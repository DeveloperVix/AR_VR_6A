using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    Color[] colors;

    Renderer thisRend; 

    float transitionTime = 5f; 

    void Start()

    {

        thisRend = GetComponent<Renderer>(); 

        colors = new Color[4]; // We will randomize through this array

        //initialize our array indexes with colors

        colors[0] = Color.red;

        colors[1] = Color.green;

        colors[2] = Color.blue;

        colors[3] = Color.yellow;

        //start our coroutine when the game starts

        StartCoroutine(ColorChang());

    }

    void Update()

    {

    }

    IEnumerator ColorChang()

    {

        //Infinite loop will ensure our coroutine runs all game

        while (true)

        {

            Color newColor = colors[(Random.Range(0, 3))]; // Assign newColor to a random color from our array

            float transitionRate = 0; 

            while (transitionRate < 1)

            {

                //this next line is how we change our material color property. We Lerp between the current color and newColor

                thisRend.material.SetColor("_Color", Color.Lerp(thisRend.material.color, newColor, Time.deltaTime * transitionRate));

                transitionRate += Time.deltaTime / transitionTime; // Increment transitionRate over the length of transitionTime
                
                yield return null; // wait for a frame then loop again

            }
            yield return new WaitForSeconds(0.5f);
            //yield return null; // wait for a frame then loop again

        }

    }
}
