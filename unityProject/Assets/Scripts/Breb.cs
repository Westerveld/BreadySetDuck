using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breb : MonoBehaviour
{
    public bool isSpinning;
    public float spinSpeed;

    // Update is called once per frame
    void Update()
    {
        if (isSpinning)
            transform.Rotate(Vector3.forward * Time.deltaTime * spinSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            other.gameObject.GetComponentInParent<CarScript>().GetBreb();
            Destroy(this.gameObject);
        }
    }
}
