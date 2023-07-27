using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitScreenWidth : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Camera mainCamera;
    public float lineWidth;
    
    private Vector3 startPos;
    private Vector3 endPos;
    private float screenWidth;

    private Vector3 previousTouchPosition;
    private Vector3 currentTouchPosition;
    private Vector3 direction;
    private float distance;

    void Start()
    {
        float screenHeight = mainCamera.orthographicSize * 2.0f;
        screenWidth = screenHeight * Screen.width / Screen.height;

        lineWidth = Mathf.Clamp(lineWidth, 0.0f, screenWidth);

        startPos = new Vector3(-screenWidth / 2f, 0f, 0f);
        endPos = new Vector3(screenWidth / 2f, 0f, 0f);

        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                currentTouchPosition = mainCamera.ScreenToWorldPoint(touch.position);
                currentTouchPosition.z = 0f;

                if (previousTouchPosition != Vector3.zero)
                {
                    direction = currentTouchPosition - previousTouchPosition;
                    distance = direction.magnitude;
                    direction.Normalize();

                    if (direction.x > 0)
                    {
                        startPos.x += distance;
                        endPos.x += distance;

                        if (endPos.x > screenWidth / 2f)
                        {
                            float excess = endPos.x - screenWidth / 2f;
                            startPos.x -= excess;
                            endPos.x -= excess;
                        }
                    }
                    else if (direction.x < 0)
                    {
                        startPos.x -= distance;
                        endPos.x -= distance;

                        if (startPos.x < -screenWidth / 2f)
                        {
                            float excess = Mathf.Abs(startPos.x) - screenWidth / 2f;
                            startPos.x += excess;
                            endPos.x += excess;
                        }
                    }

                    lineRenderer.SetPosition(0, startPos);
                    lineRenderer.SetPosition(1, endPos);
                }

                previousTouchPosition = currentTouchPosition;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                previousTouchPosition = Vector3.zero;
            }
        }
    }
}
