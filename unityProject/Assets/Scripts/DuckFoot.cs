using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckFoot : MonoBehaviour
{
    Vector3 footMiddle = new Vector3(0, 0, 0);
    public Vector3 legOffScreen;
    public float speed;

    LineRenderer legRender;
    RectTransform thisLeg;

    Vector3 offScreenMin = new Vector3(-1000, -1000, 0);
    Vector3 offScreenMax = new Vector3(1000, 1000, 0);

    Vector3 newPosition;

    bool isPlayerHoldingFoot;

    private Vector3 screenPoint;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        legRender = gameObject.GetComponent<LineRenderer>();
        thisLeg = gameObject.GetComponent<RectTransform>();

        //PickLegOffScreen(legOffScreen);
        //Debug.Log(legOffScreen);

        legRender.SetPosition(0, footMiddle);
        legRender.SetPosition(1, legOffScreen);
        PickNewPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerHoldingFoot)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);
        }
        else
        {

        }
    }

    /*Vector3 PickLegOffScreen(Vector3 targetVector)
    {
        MathUtilities.Random(ref targetVector, offScreenMin, offScreenMax);

        while (fullScreenRect.Contains(targetVector))
        {
            MathUtilities.Random(ref targetVector, offScreenMin, offScreenMax);
            Debug.Log(targetVector);
        }

        return targetVector;
    }*/

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
        speed = Random.Range(2, 5);

        newPosition = new Vector3(newX, newY, 0);
        Debug.Log(newPosition);

        float waitForNewPosition = RandomTime(3, 6);


        Invoke("PickNewPosition", waitForNewPosition);
    }

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        isPlayerHoldingFoot = true;
        Debug.Log("FootClicked");
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }

    private void OnMouseUp()
    {
        isPlayerHoldingFoot = false;
        Debug.Log("FootLetGo");
    }
}
