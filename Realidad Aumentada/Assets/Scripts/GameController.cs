using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //public enum PuzzleActual { Null, Cara1, Cara2, Cara3, Cara4, Cara5, Cara6};
    //public PuzzleActual status = PuzzleActual.Null;

    public static GameController act;
    
    public GameObject buscaTxt1;
    public GameObject puzzle1;
    public GameObject puzzle2;
    public GameObject puzzle3;

    // Start is called before the first frame update
    void Start()
    {
        act = this;
        buscaTxt1.SetActive(false);             //Se desaparece el texto de buscar
        puzzle2.SetActive(false);               //Se desaparece el segundo puzzle en escena
        puzzle3.SetActive(false);               //Se desaparece el tercer puzzle en escena
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
        //puzzle4.SetActive(true);                //Activa el puzzle 3
    }



}
