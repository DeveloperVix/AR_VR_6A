using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public static event Action PuzzleDone = delegate { };

    [SerializeField]
    private Transform standposition;

    private Vector2 initialPosition;

    private Renderer rend;

    private float deltaX, deltaY;

    private bool moveAllowed;

    private bool locked;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        rend = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchpos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    if(GetComponent<Collider>() == Physics2D.OverlapPoint(touchpos))
                    {
                        moveAllowed = true;
                        rend.sortingOrder = 3;
                        deltaX = touchpos.x - transform.position.x;
                        deltaY = touchpos.y - transform.position.y;
                    }

                    break;

                case TouchPhase.Moved:

                    if (moveAllowed)
                        transform.position = new Vector2(touchpos.x - deltaX, touchpos.y - deltaY);

                    break;

                case TouchPhase.Ended:

                    moveAllowed = false;
                    rend.sortingOrder = 2;

                    if (Mathf.Abs(transform.position.x - standposition.position.x) <= 1f &&
                       Mathf.Abs(transform.position.y - standposition.position.y) <= 5f)
                    {
                        switch (PiramidControl.slotsOccupied)
                        {
                            case 0:
                                transform.position = new Vector2(standposition.position.x, -0.006f);
                                PiramidControl.slotsOccupied = 1;
                                break;

                            case 1:
                                transform.position = new Vector2(standposition.position.x, 0.095f);
                                PiramidControl.slotsOccupied = 2;
                                break;

                            case 2:
                                transform.position = new Vector2(standposition.position.x, 0.199f);
                                PiramidControl.slotsOccupied = 3;
                                break;

                            case 3:
                                transform.position = new Vector2(standposition.position.x, 0.303f);
                                PuzzleDone();
                                break;
                        }

                        locked = true;
                    }
                    else
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    break;
            }
        }
        
    }
}
