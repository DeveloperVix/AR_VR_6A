using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Vuforia;

public class PuzzleMultiTarget : MonoBehaviour
{
    DefaultTrackableEventHandler statusImg;

    RaycastHit rayHit;
    public LayerMask caraCubo;
    private Text Instructions;

    Camera thisCamera;

    //Completing the game
    public GameObject[] right;
    public GameObject YOUWIN;

    //Puzzle Objects Capsule Game
    
    
    [Header("Capsule Puzzle")]
    public GameObject Capsule;
    public bool CapsuleWin = false;
    [SerializeField]
    protected Transform[] waypoints;
    protected int waypointIndex = 0;


    //Puzzle Scale
    [Header("Scale Puzzle")]
    public GameObject Scaler;
    public bool ScaleWin = false;
    public bool scaleAvailable = true;

    //Puzzle Destroy
    [Header ("Destroy Puzzle")]
    public GameObject DestroyPuzzle;
    public bool DestroyWin = false;
    public bool destroyBegins = false;

    //Puzzle Tree
    [Header("Tree Puzzle")]
    public GameObject Tree;
    public bool TreeWin = false;
    public bool TreeAvailable = true;

    //Puzzle Catch The Ball
    [Header("Catch The Ball")]
    public GameObject BallPuzzle;
    public bool BallWin = false;
    public bool BallBegins = false;


    //Puzzle Hello World
    [Header("Hello World Puzzle")]
    public GameObject HelloBttns;
    public GameObject HelloWorld;
    public bool HelloWin = false;

    // Start is called before the first frame update
    void Start()
    {
        YOUWIN.SetActive(false);
        statusImg = GetComponent<DefaultTrackableEventHandler>();
        
        for(int i = 0; i <= 5; i++)
        {
            right[i].SetActive(false);
        }
        Instructions = GameObject.Find("Canvas/Instructions").GetComponent<Text>();
        Capsule.transform.position = waypoints[waypointIndex].transform.position;
        HelloBttns.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        ClickOnScreen();

        if(CapsuleWin == true && ScaleWin == true && DestroyWin == true && TreeWin == true && BallWin == true && HelloWin == true)
        {
            YOUWIN.SetActive(true);
        }
    }

    public void ClickOnScreen()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,9))
            {
                HelloBttns.SetActive(false);
               if (hit.transform.name == "Capsule")
                {
                    CapsuleGame();
                    Instructions.text = "Da CLICK sobre la \n Capsula";
                    //HelloBttns.SetActive(false);
                    Debug.LogError("CLICK");

                }
                                
            }
            if (Physics.Raycast(ray, out hit, 10))
            {
                if (hit.transform.name == "HelloWorld")
                {
                    Debug.LogError("HELLOWORLD");
                    HelloBttns.SetActive(true);
                    Instructions.text = "Elige la letra que falta";
                    Debug.LogError("CLICK");
                }
            }
            if (Physics.Raycast(ray, out hit, 11))
            {
                if (hit.transform.name == "Scale")
                {
                    
                    HelloBttns.SetActive(false);
                    ScaleGame();
                    Instructions.text = "Haz Click para agrandar el cubo";
                    Debug.LogError("CLICK");
                }
            }
            if (Physics.Raycast(ray, out hit, 12))
            {
                if (hit.transform.name == "Destroyer")
                {

                    HelloBttns.SetActive(false);
                    DestroyerGame();
                    Instructions.text = "Haz Click para destruir el objeto";
                    Debug.LogError("CLICK");
                }
            }
            if (Physics.Raycast(ray, out hit, 13))
            {
                if (hit.transform.name == "Tree")
                {

                    HelloBttns.SetActive(false);
                    TreeGame();
                    Instructions.text = "Haz Click para agrandar el arbol";
                    Debug.LogError("CLICK");
                }
            }
            if (Physics.Raycast(ray, out hit, 14))
            {
                if (hit.transform.name == "Ball")
                {

                    HelloBttns.SetActive(false);
                    BallGame();
                    Instructions.text = "Haz Click para atrapar la pelota";
                    Debug.LogError("CLICK");
                }
            }
        }


    }

    void CapsuleGame()
    { 
        Capsule.transform.position = Vector3.MoveTowards(Capsule.transform.position, waypoints[waypointIndex].transform.position, 8 * Time.deltaTime);
        if (Capsule.transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }
        if (waypointIndex == waypoints.Length)
        {
            CapsuleWin = true;
            right[0].SetActive(true);
        }
    }

    public void ScaleGame()
    {
        
        if(scaleAvailable == true)
        {
            Scaler.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            if (Scaler.gameObject.transform.localScale == new Vector3(0.5f, 0.5f, 0.5f))
            {
                right[1].SetActive(true);
                ScaleWin = true;
                scaleAvailable = false;
            }
            
        }
        else
        {
            Scaler.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
               
        
    }

    public void DestroyerGame()
    {
        if(destroyBegins == true)
        {
            DestroyPuzzle.SetActive(false);
            right[2].SetActive(true);
            destroyBegins = false;
            DestroyWin = true;
        }
        destroyBegins = true;


    }

    public void TreeGame()
    {
        if (TreeAvailable == true)
        {
            Tree.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            if (Tree.gameObject.transform.localScale == new Vector3(0.3f, 0.3f, 0.3f))
            {
                right[3].SetActive(true);
                TreeWin = true;
                TreeAvailable = false;
            }

        }
        else
        {
            Scaler.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

    public void BallGame()
    {
        if (BallBegins == true)
        {
            BallPuzzle.SetActive(false);
            right[4].SetActive(true);
            BallWin = true;
        }
        BallBegins = true;


    }

    public void HelloGame(string Text)
    {
        TextMesh Texto = HelloWorld.gameObject.GetComponent<TextMesh>();
        if(HelloWin==false)
        {
            Texto.text = ""+Text;
            if(Texto.text == "Hello World")
            {
                HelloWin = true;
                right[5].SetActive(true);
            }
        }
        else
        {
            HelloBttns.SetActive(false);
        }
    }
}
