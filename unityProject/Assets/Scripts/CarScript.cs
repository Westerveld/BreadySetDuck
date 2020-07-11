using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Transform massCenter;

    public WheelCollider FR, FL, BR, BL;

    public float speedToPerGear;

    private void Awake()
    {
        targetRotation = transform.rotation;
        rigid = GetComponent<Rigidbody>();
        currSpeedTarget = currGear * speedToPerGear;
        //rigid.centerOfMass = massCenter.position;
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
        currSpeedTarget = currGear * speedToPerGear;
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Lerp(speed, currSpeedTarget, Time.deltaTime * acceleration);
        movement = transform.forward * constantForwardForce;
        BL.motorTorque = speed;
        BR.motorTorque = speed;
        FR.steerAngle = moveAmount;
        FL.steerAngle = moveAmount;

    }

    private void LateUpdate()
    {
        moveAmount = Mathf.Lerp(moveAmount, 0, turnSpeed);
    }
}
