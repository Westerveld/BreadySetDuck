using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    public float speedMin;
    public float speedMax;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(speedMin, speedMax);    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Debug.Log(speed);
    }


    void Dodge()
    {


    }
}
