using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarArea : MonoBehaviour
{
    public Action<bool, int> areaPressed;

    public int direction;

    public void CallInvoke(bool player)
    {
        Debug.Log(name + ", pressed");
        areaPressed(player, direction);
    }

}
