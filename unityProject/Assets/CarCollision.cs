using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    public GameObject carParent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
            Debug.Log("collided with obstacles");
            if (other.GetComponent<Obstacle>().doesDamage)
            {
                other.GetComponent<Obstacle>().Hit();
                carParent.GetComponent<CarScript>().OofOwwieOuchie();
            }
        }
    }
}
