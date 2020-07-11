using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckFoot : MonoBehaviour
{
    Vector3 footMiddle = new Vector3(0, 0, 0);
    public Vector3 legOffScreen;
    private float speed;

    LineRenderer legRender;
    RectTransform thisLeg;

    Vector3 offScreenMin = new Vector3(-200, -200, 0);
    Vector3 offScreenMax = new Vector3(200, 200, 0);

    Vector3 newPosition;

    bool isPlayerHoldingFoot;

    private Vector3 screenPoint;
    private Vector3 offset;

    Rect fullScreenRect;

    public float minSpeed;
    public float maxSpeed;

    public Camera cam;
    private Vector3 cameraBasedPosition;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(fullScreenRect);
        fullScreenRect = new Rect(0, 0, Screen.width, Screen.height);
        legRender = gameObject.GetComponent<LineRenderer>();
        thisLeg = gameObject.GetComponent<RectTransform>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();

        legRender.SetPosition(0, footMiddle);
        legRender.SetPosition(1, PickLegOffScreen(legOffScreen));
        PickNewPosition();
    }

    // Update is called once per frame
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

        if(fullScreenRect.Contains(cameraBasedPosition))
        {
            Debug.Log("We in");
        }
        else
        {
            Debug.Log("We out");
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
        newX = Random.Range(this.transform.position.x - 10, this.transform.position.y + 10);
        newY = Random.Range(this.transform.position.x - 10, this.transform.position.y + 10);
        speed = Random.Range(minSpeed, maxSpeed);

        newPosition = new Vector3(newX, newY, 0);

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
