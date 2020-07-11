using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummytest : MonoBehaviour
{

    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] corners = new Vector3[4];
        rect.GetWorldCorners(corners);
        Debug.Log("Screen point1: " + new Vector3(rect.rect.xMax, rect.rect.yMin, 0) + rect.position);
        foreach (Vector3 corner in corners)
        {
            Debug.Log("World point: " + corner);
            Debug.Log("Screen point: " + RectTransformUtility.WorldToScreenPoint(null, corner));
            Debug.Log("Viewport: " + Camera.main.ScreenToViewportPoint(corner));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
