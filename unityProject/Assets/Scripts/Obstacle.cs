using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float timeBetweenDamaging = 3.5f;

    public bool doesDamage =true;
    public void Hit()
    {
        doesDamage = false;
        Invoke("AllowDamage", timeBetweenDamaging);
    }

    void AllowDamage()
    {
        doesDamage = true;
    }
}
