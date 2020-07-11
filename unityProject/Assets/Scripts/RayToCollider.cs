using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayToCollider : MonoBehaviour
{
    public Camera cam;
    Vector3 mousePos,worldpos;
    RaycastHit hit;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane);
            ray = cam.ScreenPointToRay(mousePos);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.DrawLine(worldpos, hit.transform.position);
                if(hit.collider.gameObject.GetComponent<CarArea>())
                {
                    hit.collider.gameObject.GetComponent<CarArea>().CallInvoke(true);
                }
            }
        }
    }
}
