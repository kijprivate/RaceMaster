using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    enum Position  {Left,Center,Right };
    Position myPosition = Position.Center;

    [SerializeField]
    float speed = 5f;

    [SerializeField]
    PlayerMovement player;

    Animator animator;

    Vector3 touchPtScreen;
    Vector3 startTouchPt;

    Vector3 leftPos;
    Vector3 centerPos;
    Vector3 rightPos;

    bool isClicked = false;
    // Use this for initialization
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        myPosition = Position.Center; 
    }

    // Update is called once per frame
    void Update()
    {
        GetStartingMousePos();

        ChangePosition();
    }



    private void GetStartingMousePos()
    {
        if (Input.GetMouseButtonDown(0) && !isClicked)
        {
            //get the screen coordinates of the touch
            touchPtScreen = CrossPlatformInputManager.mousePosition;

            //save the starting touch point in SCREEN SPACE
            startTouchPt = touchPtScreen;

            isClicked = true;
        }
    }

    private void ChangePosition()
    {
        
        if (Input.GetMouseButton(0) && CrossPlatformInputManager.mousePosition != startTouchPt && isClicked)
        {
            switch (myPosition)
            {
                case Position.Left:
                    if (startTouchPt.x - CrossPlatformInputManager.mousePosition.x < 0)
                    {
                        animator.SetTrigger("CenterFromLeft");
                        myPosition = Position.Center;
                        isClicked = false;
                       // print(myPosition);
                    }
                    break;
                case Position.Center:
                    if (startTouchPt.x - CrossPlatformInputManager.mousePosition.x > 0)
                    {
                        animator.SetTrigger("MoveLeft");
                        myPosition = Position.Left;
                        isClicked = false;
                       // print(myPosition);
                    }
                    else if (startTouchPt.x - CrossPlatformInputManager.mousePosition.x < 0)
                    {
                        animator.SetTrigger("MoveRight");
                        myPosition = Position.Right;
                        isClicked = false;
                       // print(myPosition);
                    }
                    break;
                case Position.Right:
                    if (startTouchPt.x - CrossPlatformInputManager.mousePosition.x > 0)
                    {
                        animator.SetTrigger("CenterFromRight");
                        myPosition = Position.Center;
                        isClicked = false;
                       // print(myPosition);
                    }
                    break;
            }
        }
    }
}
