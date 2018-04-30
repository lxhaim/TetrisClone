using System;
using Assets.Scripts.Core;
using UnityEngine;

public class TouchInputManager : MonoBehaviour, IInputManager
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField]
    private bool detectSwipeOnlyAfterRelease = false;

    [SerializeField]
    private float minDistanceForSwipe = 20f;

    public event Action MoveRight = delegate { };
    public event Action MoveLeft = delegate { };
    public event Action MoveDown = delegate { };
    public event Action Land = delegate { };
    public event Action Rotate = delegate { };

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPosition = touch.position;
                fingerDownPosition = touch.position;
            }

            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        if (!SwipeDistanceCheckMet())
        {
            return;
        }

        if (IsVerticalSwipe())
        {
            if (fingerDownPosition.y - fingerUpPosition.y > 0)
            {
                Rotate();
            }
            else
            {
                Land();
            }
        }
        else
        {
            if (fingerDownPosition.x - fingerUpPosition.x > 0)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
        }

        fingerUpPosition = fingerDownPosition;
    }

    private bool IsVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }

    private bool SwipeDistanceCheckMet()
    {
        return VerticalMovementDistance() > minDistanceForSwipe || HorizontalMovementDistance() > minDistanceForSwipe;
    }

    private float VerticalMovementDistance()
    {
        return Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y);
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x);
    }
}