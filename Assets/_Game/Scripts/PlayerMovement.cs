using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    enum Position  {Left,Center,Right };
    Position myPosition = Position.Center;

    MoveForwardAndCollision player;

    Animator animator;

    Vector3 touchPtScreen;
    Vector3 startTouchPt;

    bool isClicked = false;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        myPosition = Position.Center;
        player = GetComponentInChildren<MoveForwardAndCollision>();
    }

    void Update()
    {
        if (player.gameOver) { return; }

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
                    }
                    break;
                case Position.Center:
                    if (startTouchPt.x - CrossPlatformInputManager.mousePosition.x > 0)
                    {
                        animator.SetTrigger("MoveLeft");
                        myPosition = Position.Left;
                        isClicked = false;
                    }
                    else if (startTouchPt.x - CrossPlatformInputManager.mousePosition.x < 0)
                    {
                        animator.SetTrigger("MoveRight");
                        myPosition = Position.Right;
                        isClicked = false;
                    }
                    break;
                case Position.Right:
                    if (startTouchPt.x - CrossPlatformInputManager.mousePosition.x > 0)
                    {
                        animator.SetTrigger("CenterFromRight");
                        myPosition = Position.Center;
                        isClicked = false;
                    }
                    break;
            }
        }
    }
}
