using System.Collections;
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

    public bool isPlayerHoldingFoot;

    private Vector3 screenPoint;
    private Vector3 offset;

    Rect fullScreenRect;

    public float minSpeed;
    public float maxSpeed;

    public float moveYRange;
    public float moveXRange;

    public Camera cam;
    private Vector3 cameraBasedPosition;

    private Vector2 viewportBounds;
    public Vector3 footOffset;

    public Vector3 fVector;
    float angle;
    public float angleSmoothing;

    public bool canInteract = true;
    public float coolDownTime = 1.25f;
    

    void Start()
    {
        viewportBounds = cam.ViewportToWorldPoint(Vector2.one);

        fullScreenRect = new Rect(0, 0, viewportBounds.x, viewportBounds.y);

        legRender = gameObject.GetComponent<LineRenderer>();

        //cam = GameObject.Find("Camera").GetComponent<Camera>();

        legRender.SetPosition(0, footMiddle);
        legRender.SetPosition(1, PickLegOffScreen(legOffScreen));
        PickNewPosition();

        fVector = legRender.GetPosition(0) - legRender.GetPosition(1);
        angle = Mathf.Atan2(fVector.y, fVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * angleSmoothing);
        legRender.material.mainTextureScale = new Vector2(legRender.material.mainTextureScale.x, Random.value);
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

    private void LateUpdate()
    {
        fVector = legRender.GetPosition(0) - legRender.GetPosition(1);
        angle = Mathf.Atan2(fVector.y, fVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle - 90, Vector3.forward), Time.deltaTime * angleSmoothing);
    }

    Vector3 PickLegOffScreen(Vector3 targetVector)
    {
        MathUtilities.Random(ref targetVector, offScreenMin, offScreenMax);
        legOffScreen = cam.ViewportToWorldPoint(new Vector3(targetVector.x, targetVector.y, cam.nearClipPlane));
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

        newX = Random.value;
        newY = Random.value;

        speed = Random.Range(minSpeed, maxSpeed);

        newPosition = new Vector3(newX, newY, cam.nearClipPlane + footOffset.z);

        newPosition = cam.ViewportToWorldPoint(newPosition);


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

    public void Interacted()
    {
        canInteract = false;
        Invoke("AllowInteract", coolDownTime);
    }

    void AllowInteract()
    {
        canInteract = true;
    }
}
