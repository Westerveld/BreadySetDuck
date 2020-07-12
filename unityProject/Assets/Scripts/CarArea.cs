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

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Foot"))
        {
            DuckFoot foot = other.GetComponent<DuckFoot>();
            if(foot.isPlayerHoldingFoot)
            {
                CallInvoke(true);
            }
            else
            {
                if (foot.canInteract)
                {
                    CallInvoke(false);
                    foot.Interacted();
                }
            }
        }
    }

}
