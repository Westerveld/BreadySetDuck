using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarArea : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Duck"))
        {
            //check if its user controlled, if it is we need to wait.
        }
    }
}
