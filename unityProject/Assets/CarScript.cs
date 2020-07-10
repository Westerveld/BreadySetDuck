using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarScript : MonoBehaviour
{
    public CarArea wheelLeft, wheelRight, gearUp, gearDown, lighter, horn, map;

    public float constantForwardForce, turning, turnSpeed, acceleration;
    float moveAmount;
    Rigidbody rigid;
    public int currGear = 1, maxGears= 6;
    float speed, currSpeedTarget;

    public Vector3 movement;
    Quaternion targetRotation;

    private void Awake()
    {
        targetRotation = transform.rotation;
        rigid = GetComponent<Rigidbody>();
        currSpeedTarget = currGear * 5;
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        wheelLeft.areaPressed += WheelMove;
        wheelRight.areaPressed += WheelMove;
        gearUp.areaPressed += GearMove;
        gearDown.areaPressed += GearMove;
    }

    private void OnDisable()
    {
        wheelLeft.areaPressed -= WheelMove;
        wheelRight.areaPressed -= WheelMove;
        gearUp.areaPressed -= GearMove;
        gearDown.areaPressed -= GearMove;
    }

    void WheelMove(bool player, int dir)
    {
        moveAmount = dir * turning;
        targetRotation *= Quaternion.Euler(0, moveAmount, 0);
    }

    void GearMove(bool player, int dir)
    {
        if(dir == -1)
        {
            if(currGear >= 0)
            {
                currGear--;
                
            }
        }
        else if(dir == 1)
        {
            if(currGear < 6)
                currGear++;
        }
        currSpeedTarget = currGear * 5;
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Lerp(speed, currSpeedTarget, Time.deltaTime * acceleration);
        movement = transform.forward * constantForwardForce;
        rigid.AddForce(movement * speed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
}
