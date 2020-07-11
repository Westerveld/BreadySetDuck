﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckFoot : MonoBehaviour
{
    Vector3 footMiddle = new Vector3(0, 0, 0);
    public Vector3 legOffScreen;
    private float speed;

    LineRenderer legRender;

    Vector3 offScreenMin;
    Vector3 offScreenMax;
    Vector3 screenBounds;

    Vector3 newPosition;

    bool isPlayerHoldingFoot;

    private Vector3 screenPoint;
    private Vector3 offset;

    Rect fullScreenRect;

    public float minSpeed;
    public float maxSpeed;

    public float moveYRange;
    public float moveXRange;

    public Camera cam;
    private Vector3 cameraBasedPosition;


    void Start()
    {
        screenBounds = cam.WorldToScreenPoint(transform.position);
        Debug.Log(screenBounds);

        fullScreenRect = new Rect(0, 0, Screen.width, Screen.height);
        Debug.Log(fullScreenRect);

        legRender = gameObject.GetComponent<LineRenderer>();

        cam = GameObject.Find("Camera").GetComponent<Camera>();

        offScreenMin = new Vector3(fullScreenRect.xMin, fullScreenRect.yMin, 0);
        offScreenMax = new Vector3(fullScreenRect.xMax, fullScreenRect.yMax, 0);

        offScreenMin = cam.WorldToScreenPoint(offScreenMin);

        Debug.Log(offScreenMin);

        legRender.SetPosition(0, footMiddle);
        legRender.SetPosition(1, PickLegOffScreen(legOffScreen));
        PickNewPosition();
    }

    void Update()
    {
        cameraBasedPosition = cam.WorldToScreenPoint(transform.position);

        legRender.SetPosition(0, transform.position);
        legRender.SetPosition(1, legOffScreen);

        if (!isPlayerHoldingFoot)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);
        }
        else
        {
            newPosition = transform.position;
        }
    }

    Vector3 PickLegOffScreen(Vector3 targetVector)
    {
        MathUtilities.Random(ref targetVector, offScreenMin, offScreenMax);
        legOffScreen = targetVector;
        return targetVector;
    }

    float RandomTime(float min, float max)
    {
        float resultingFloat;
        resultingFloat = Random.Range(min, max);
        return resultingFloat;
    }

    void PickNewPosition()
    {
        float newX, newY;
        Vector3 cameraTest;

        newX = Random.Range(this.transform.position.x - moveXRange, this.transform.position.y + moveXRange);
        newY = Random.Range(this.transform.position.y - moveYRange, this.transform.position.y + moveYRange);
        speed = Random.Range(minSpeed, maxSpeed);

        newPosition = new Vector3(newX, newY, 0);
        cameraTest = cam.WorldToScreenPoint(newPosition);

        float waitForNewPosition = RandomTime(3, 6);

        Invoke("PickNewPosition", waitForNewPosition);
    }

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        isPlayerHoldingFoot = true;
        Debug.Log("FootClicked");
        CancelInvoke("PickNewPosition");
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        legRender.SetPosition(1, legOffScreen);
    }

    private void OnMouseUp()
    {
        isPlayerHoldingFoot = false;
        PickNewPosition();
        Debug.Log("FootLetGo");
    }
}
