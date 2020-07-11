using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    public float speedMin;
    public float speedMax;

    private float speed;
    private Collider objectCollider;

    bool dodged = false;

    Animator objectAnimator;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(speedMin, speedMax);

        objectCollider = GetComponent<BoxCollider>();
        objectAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!dodged)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dodge();
        }
    }


    void Dodge()
    {
        objectCollider.enabled = false;
        dodged = true;

        objectAnimator.SetTrigger("Dodge");
        objectAnimator.SetInteger("RandomAnim", Random.Range(0, 10));
        
    }
}
