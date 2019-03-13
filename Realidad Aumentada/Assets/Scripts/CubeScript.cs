using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeScript : MonoBehaviour
{
    public static CubeScript act;

    //OBJETOS A UTILIZAR
    public GameObject sphere;
    public GameObject sphere2;
    public GameObject sphere3;
    public GameObject redCubeObj;
    public GameObject greenCubeObj;
    public GameObject greenCube2Obj;
    public GameObject notFoundTarget;
    public GameObject puzzle1;
    public GameObject puzzle2;
    public GameObject puzzle3;
    public GameObject puzzle4;
    public GameObject puzzle5;
    public GameObject puzzle6;
    public GameObject instructions;

    //LAYERS DE OBJETOS
    public LayerMask cubeSelected;
    public LayerMask sphereSelected;
    public LayerMask sphereSelected2;
    public LayerMask sphereSelected3;
    public LayerMask redCubeSelected;
    public LayerMask greenCubeSelected;
    public LayerMask yellowCubeSelected;
    public LayerMask puzzle1Layer;
    public LayerMask puzzle2Layer;
    public LayerMask puzzle3Layer;
    public LayerMask puzzle4Layer;
    public LayerMask puzzle5Layer;
    public LayerMask puzzle6Layer;

    //MATERIAL
    public Material redCube;

    //CAMARA DEL JUEGO
    Camera thisCamera;

    //VECTOR 3 DE LA POSICION INICIAL DEL MOUSE
    Vector3 mouseInitialPosition;

    //COMPONENTE ANIMATOR
    public Animator anim;

    //VARIABLE DE CODIGO
    public DefaultTrackableEventHandler statusAnim;

    //MESH RENDERER DE LA FIGURA
    public MeshRenderer meshCube;

    void Awake()
    {
        act = this;
        thisCamera = GetComponent<Camera>();                         //Accedemos a los componentes
        statusAnim.GetComponent<DefaultTrackableEventHandler>();     //Obtenemos los componentes de DefaultTrackableEventHandler
        puzzle1.SetActive(false);
        puzzle2.SetActive(false);
        puzzle3.SetActive(false);
        puzzle4.SetActive(false);
        puzzle5.SetActive(false);
        puzzle6.SetActive(false);
        instructions.SetActive(false);

    }

    void Update()
    {
        if (statusAnim.isDetected == true)                                                                                           //Si se detecto el target
        {
            notFoundTarget.SetActive(false);
            instructions.SetActive(true);
            if (Input.GetMouseButtonDown(0))                                                                                         //Si ha sido presionado el click izquierdo
            {
                mouseInitialPosition = thisCamera.ScreenToViewportPoint(Input.mousePosition);                                        //Transforma las coordenadas de pantalla en un espacio de viewport(nos retorna coordenadas de 0 a 1)
                RaycastHit rayHit;                                                                                                   //Fisicas raycast(objetos que tengan un collider)



                //PUZZLE 1
                if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, puzzle1Layer))
                {
                    puzzle1.SetActive(true);
                    GameController.act.backgroundPuzzle1.SetActive(true);
                    //GameController.act.puzzle1.SetActive(false);
                    if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, sphereSelected))   //Si el click del mouse colisiona con el layer de sphereSelected...
                    {
                        Vector3 scaleSphere = sphere.transform.localScale;                                                               //Se crea un vector 3 que guardara la escala de la sphere
                        scaleSphere.x += 0.2f;                                                                                           //Se le agrega en x 0.2 cada vez que pase por aqui
                        scaleSphere.y += 0.2f;                                                                                           //Se le agrega en y 0.2 cada vez que pase por aqui
                        scaleSphere.z += 0.2f;                                                                                           //Se le agrega en z 0.2 cada vez que pase por aqui
                        sphere.transform.localScale = scaleSphere;                                                                       //Se le agregara la variable del vector 3 y se le asignara a la escala de la sphere
                    }
                }



                //PUZZLE 2
                if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, puzzle2Layer))
                {
                    puzzle2.SetActive(true);
                    GameController.act.backgroundPuzzle2.SetActive(true);
                    if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, cubeSelected))     //Si el click del mouse colisiona con el layer de cubeSelected...
                    {
                        meshCube.material = redCube;                                                                                     //Se le agrega el materiaul de redCube al cubo
                        anim.SetBool("animActive", false);                                                                               //La animacion se detiene
                        GameController.act.Puzzle3();                                                                                    //Inicial el metodo llamado Puzzle3 del GameController

                    }
                }



                //PUZZLE 3
                if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, puzzle3Layer))
                {
                    puzzle3.SetActive(true);
                    GameController.act.backgroundPuzzle3.SetActive(true);
                    if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, sphereSelected2))  //Si el click del mouse colisiona con el layer de sphereSelected2...
                    {
                        sphere2.transform.Rotate(0, sphere2.transform.rotation.y + 10, 0);                                               //Se le agregara en su rotacion en y + 10
                    }

                    if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, sphereSelected3))  //Si el click del mouse colisiona con el layer de sphereSelected3...
                    {
                        sphere3.transform.Rotate(0, sphere3.transform.rotation.y - 10, 0);                                               //Se le agregara en su rotacion en y - 10
                    }
                }



                //PUZZLE 4
                if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, puzzle4Layer))
                {
                    GameController.act.backgroundPuzzle4.SetActive(true);
                    puzzle4.SetActive(true);
                    GameController.act.wasdTxtRedCube.SetActive(true);
                }



                //PUZZLE 5
                if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, puzzle5Layer))
                {
                    GameController.act.backgroundPuzzle5.SetActive(true);
                    puzzle5.SetActive(true);
                    GameController.act.wasdTxtSphere.SetActive(true);

                }


                //PUZZLE 6
                if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, puzzle6Layer))
                {
                    puzzle6.SetActive(true);
                    GameController.act.backgroundPuzzle6.SetActive(true);
                    GameController.act.backgroundColor.SetActive(true);
                    int i = 0;
                    if(i <= 0)
                    {
                        GameController.act.AparicionImage();
                    }
                    i++;
                    
                    if (GameController.act.redImage.activeInHierarchy)
                    {
                        if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, redCubeSelected))  //Si el click del mouse colisiona con el layer de sphereSelected2...
                        {
                            GameController.act.Finish();
                        }
                    }

                    if (GameController.act.greenImage.activeInHierarchy)
                    {
                        if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, greenCubeSelected))  //Si el click del mouse colisiona con el layer de sphereSelected2...
                        {
                            GameController.act.Finish();
                        }
                    }

                    if (GameController.act.yellowImage.activeInHierarchy)
                    {
                        if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, yellowCubeSelected))  //Si el click del mouse colisiona con el layer de sphereSelected2...
                        {
                            GameController.act.Finish();
                        }
                    }
                }
            }
        }
        else
        {
            if (statusAnim.isDetected == false)
            {
                //anim.SetBool("animActive", false);
                notFoundTarget.SetActive(true);
            }
        }
        
    }

}
