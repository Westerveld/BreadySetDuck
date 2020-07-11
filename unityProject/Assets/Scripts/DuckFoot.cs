using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckFoot : MonoBehaviour
{

    private Rect fullScreenRect = new Rect(0, 0, Screen.width, Screen.height);

    Vector3 footMiddle = new Vector3(0, 0, 0);
    public Vector3 legOffScreen;
    public float speed;

    LineRenderer legRender;

    Vector3 offScreenMin = new Vector3(-1000, -1000, 0);
    Vector3 offScreenMax = new Vector3(1000, 1000, 0);

    Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        legRender = gameObject.GetComponent<LineRenderer>();

        PickLegOffScreen(legOffScreen);
        //Debug.Log(legOffScreen);

        legRender.SetPosition(0, footMiddle);
        legRender.SetPosition(1, legOffScreen);
        Debug.Log(fullScreenRect);
        PickNewPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 PickLegOffScreen(Vector3 targetVector)
    {
        MathUtilities.Random(ref targetVector, offScreenMin, offScreenMax);

        while (fullScreenRect.Contains(targetVector))
        {
            MathUtilities.Random(ref targetVector, offScreenMin, offScreenMax);
            Debug.Log(targetVector);
        }

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
        int newX, newY;
        newX = Random.Range(-1000, 1000);
        newY = Random.Range(-1000, 1000);
        speed = Random.Range(3, 10);

        newPosition = new Vector3(newX, newY, 0);

        float waitForNewPosition = RandomTime(3, 6);

        transform.Translate(newPosition * speed * Time.deltaTime);
        Invoke("PickNewPosition", waitForNewPosition);
    }
}
