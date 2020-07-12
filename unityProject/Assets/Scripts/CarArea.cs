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
        areaPressed(player, direction);
        AudioManager._instance.PlayFoot();
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

            //foot.FootUsed();
        }
    }

}
