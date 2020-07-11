using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarArea : MonoBehaviour
{
    public Action<bool, int> areaPressed;

    public int direction;
    public Animator anim;
    public string trigger;

    public void CallInvoke(bool player)
    {
        Debug.Log(name + ", pressed");
        areaPressed(player, direction);
        if (anim != null)
            anim.SetTrigger(trigger);
    }

}
