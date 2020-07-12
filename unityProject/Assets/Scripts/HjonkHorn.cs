using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HjonkHorn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Foot"))
        {
            other.GetComponent<DuckFoot>().Hjonk();
            //other.GetComponent<DuckFoot>().FootUsed();
        }
    }
}
