using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeScript : MonoBehaviour
{
    //OBJETOS A UTILIZAR

    public GameObject sphere;
    public GameObject sphere2;
    public GameObject sphere3;
    public GameObject redCubeObj;
    public GameObject greenCubeObj;
    public GameObject greenCube2Obj;

    //LAYERS DE OBJETOS
    public LayerMask cubeSelected;
    public LayerMask sphereSelected;
    public LayerMask sphereSelected2;
    public LayerMask sphereSelected3;
    public LayerMask redCubeSelected;
    public LayerMask greenCubeSelected;
    public LayerMask yellowCubeSelected;

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
        
        thisCamera = GetComponent<Camera>();                         //Accedemos a los componentes
        statusAnim.GetComponent<DefaultTrackableEventHandler>();     //Obtenemos los componentes de DefaultTrackableEventHandler


    }

    void Update()
    {
        if (statusAnim.isDetected == true)                                                                                           //Si se detecto el target
        {
            if (Input.GetMouseButtonDown(0))                                                                                         //Si ha sido presionado el click izquierdo
            {
                mouseInitialPosition = thisCamera.ScreenToViewportPoint(Input.mousePosition);                                        //Transforma las coordenadas de pantalla en un espacio de viewport(nos retorna coordenadas de 0 a 1)
                RaycastHit rayHit;                                                                                                   //Fisicas raycast(objetos que tengan un collider)



                //PUZZLE 1
                if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, sphereSelected))   //Si el click del mouse colisiona con el layer de sphereSelected...
                {
                    Vector3 scaleSphere = sphere.transform.localScale;                                                               //Se crea un vector 3 que guardara la escala de la sphere
                    scaleSphere.x += 0.2f;                                                                                           //Se le agrega en x 0.2 cada vez que pase por aqui
                    scaleSphere.y += 0.2f;                                                                                           //Se le agrega en y 0.2 cada vez que pase por aqui
                    scaleSphere.z += 0.2f;                                                                                           //Se le agrega en z 0.2 cada vez que pase por aqui
                    sphere.transform.localScale = scaleSphere;                                                                       //Se le agregara la variable del vector 3 y se le asignara a la escala de la sphere
                }


                //PUZZLE 2
                if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, cubeSelected))     //Si el click del mouse colisiona con el layer de cubeSelected...
                {
                    meshCube.material = redCube;                                                                                     //Se le agrega el materiaul de redCube al cubo
                    anim.SetBool("animActive", false);                                                                               //La animacion se detiene
                    GameController.act.Puzzle3();                                                                                    //Inicial el metodo llamado Puzzle3 del GameController
                    
                }


                //PUZZLE 3
                if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, sphereSelected2))  //Si el click del mouse colisiona con el layer de sphereSelected2...
                {
                    sphere2.transform.Rotate(0, sphere2.transform.rotation.y + 10, 0);                                               //Se le agregara en su rotacion en y + 10
                }

                if (Physics.Raycast(thisCamera.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, sphereSelected3))  //Si el click del mouse colisiona con el layer de sphereSelected3...
                {
                    sphere3.transform.Rotate(0, sphere3.transform.rotation.y - 10, 0);                                               //Se le agregara en su rotacion en y - 10
                }



                //PUZZLE 6
                if(GameController.act.redImage.activeInHierarchy)
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
        else
        {
            if (statusAnim.isDetected == false)
            {
                anim.SetBool("animActive", false);

            }
        }
        
    }

}
