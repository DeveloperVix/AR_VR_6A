using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //public enum PuzzleActual { Null, Cara1, Cara2, Cara3, Cara4, Cara5, Cara6};
    //public PuzzleActual status = PuzzleActual.Null;

    //Constructor
    public static GameController act;
    
    //Objetos a utilizar
    public GameObject buscaTxt1;
    public GameObject wasdTxtRedCube;
    public GameObject wasdTxtSphere;
    public GameObject finishBackground;
    public GameObject puzzle1;
    public GameObject puzzle2;
    public GameObject puzzle3;
    public GameObject puzzle4;
    public GameObject puzzle5;
    public GameObject puzzle6;
    public GameObject redImage;
    public GameObject greenImage;
    public GameObject yellowImage;
    public GameObject backgroundColor;
    public GameObject backgroundPuzzle1;
    public GameObject backgroundPuzzle2;
    public GameObject backgroundPuzzle3;
    public GameObject backgroundPuzzle4;
    public GameObject backgroundPuzzle5;
    public GameObject backgroundPuzzle6;



    void Start()
    {
        act = this;                             //El constructor sera este codigo

        buscaTxt1.SetActive(false);             //Se desaparece el texto de buscar
        wasdTxtRedCube.SetActive(false);
        wasdTxtSphere.SetActive(false);
        puzzle2.SetActive(false);               //Se desaparece el segundo puzzle en escena
        puzzle3.SetActive(false);               //Se desaparece el tercer puzzle en escena
        puzzle4.SetActive(false);               //Se desaparece el cuarto puzzle en escena
        puzzle5.SetActive(false);
        puzzle6.SetActive(false);
        redImage.SetActive(false);
        greenImage.SetActive(false);
        yellowImage.SetActive(false);
        finishBackground.SetActive(false);
        backgroundColor.SetActive(false);
        backgroundPuzzle1.SetActive(false);
        backgroundPuzzle2.SetActive(false);
        backgroundPuzzle3.SetActive(false);
        backgroundPuzzle4.SetActive(false);
        backgroundPuzzle5.SetActive(false);
        backgroundPuzzle6.SetActive(false);
    }


    //PUZZLE 2
    public void Puzzle2()
    {
        buscaTxt1.SetActive(true);              //Activamos el texto de buscar
        StartCoroutine(AparicionPuzzle2());     //Inicia coroutina
    }
    
    IEnumerator AparicionPuzzle2()           
    {
        yield return new WaitForSeconds(1f);    //Se espera un segundo
        buscaTxt1.SetActive(false);             //Desactiva el texto de buscar
        puzzle1.SetActive(false);               //Desactiva el puzzle 1
        CubeScript.act.puzzle1.SetActive(false);
        backgroundPuzzle1.SetActive(false);
        puzzle2.SetActive(true);                //Activa el puzzle 2

        
    }



    //PUZZLE 3
    public void Puzzle3()
    {
        buscaTxt1.SetActive(true);              //Activamos el texto de buscar
        StartCoroutine(AparicionPuzzle3());     //Inicia coroutina
    }

    IEnumerator AparicionPuzzle3()
    {
        yield return new WaitForSeconds(1f);    //Se espera un segundo
        buscaTxt1.SetActive(false);             //Desactiva el texto de buscar
        puzzle2.SetActive(false);               //Desactiva el puzzle 2
        CubeScript.act.puzzle2.SetActive(false);
        backgroundPuzzle2.SetActive(false);
        puzzle3.SetActive(true);                //Activa el puzzle 3
       
    }



    //PUZZLE 4
    public void Puzzle4()
    {
        buscaTxt1.SetActive(true);              //Activamos el texto de buscar
        StartCoroutine(AparicionPuzzle4());     //Inicia coroutina
    }

    IEnumerator AparicionPuzzle4()
    {
        yield return new WaitForSeconds(1f);    //Se espera un segundo
        buscaTxt1.SetActive(false);             //Desactiva el texto de buscar
        puzzle3.SetActive(false);               //Desactiva el puzzle 2
        CubeScript.act.puzzle3.SetActive(false);
        backgroundPuzzle3.SetActive(false);
        puzzle4.SetActive(true);                //Activa el puzzle 3
        
    }



    //PUZZLE 5
    public void Puzzle5()
    {
        buscaTxt1.SetActive(true);              //Activamos el texto de buscar
        StartCoroutine(AparicionPuzzle5());     //Inicia coroutina
    }

    IEnumerator AparicionPuzzle5()
    {
        yield return new WaitForSeconds(1f);    //Se espera un segundo
        buscaTxt1.SetActive(false);             //Desactiva el texto de buscar
        puzzle4.SetActive(false);               //Desactiva el puzzle 2
        CubeScript.act.puzzle4.SetActive(false);
        wasdTxtRedCube.SetActive(false);
        backgroundPuzzle4.SetActive(false);
        puzzle5.SetActive(true);                //Activa el puzzle 3
    }



    //PUZZLE 6
    public void Puzzle6()
    {
        buscaTxt1.SetActive(true);              //Activamos el texto de buscar
        StartCoroutine(AparicionPuzzle6());     //Inicia coroutina
    }

    IEnumerator AparicionPuzzle6()
    {
        yield return new WaitForSeconds(1f);    //Se espera un segundo
        buscaTxt1.SetActive(false);             //Desactiva el texto de buscar
        puzzle5.SetActive(false);               //Desactiva el puzzle 2
        CubeScript.act.puzzle5.SetActive(false);
        wasdTxtSphere.SetActive(false);
        backgroundPuzzle5.SetActive(false);
        puzzle6.SetActive(true);                //Activa el puzzle 3
        
        
    }



    //FINISH
    public void Finish()
    {
        puzzle6.SetActive(false);
        CubeScript.act.puzzle6.SetActive(false);
        backgroundColor.SetActive(false);
        finishBackground.SetActive(true);
    }

    public void AparicionImage()
    {
        int i = Random.Range(1, 4);

        switch(i)
        {
            case 1:
                redImage.SetActive(true);
                break;
            case 2:
                greenImage.SetActive(true);
                break;
            case 3:
                yellowImage.SetActive(true);
                break;
        }
    }

    public void CargarEscena()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
