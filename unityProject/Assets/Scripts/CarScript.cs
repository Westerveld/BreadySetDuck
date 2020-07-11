using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public CarArea wheelLeft, wheelRight, gearUp, gearDown, lighter, horn, map;

    public float constantForwardForce, turning, turnSpeed, acceleration, turnTime;
    float targetTurn, currTurn;
    Rigidbody rigid;
    public int currGear = 1, maxGears= 6;
    float speed, currSpeed, currSpeedTarget;

    public Vector3 movement;
    Quaternion targetRotation;
    public Transform massCenter;

    public WheelCollider FR, FL, BR, BL;

    public float speedPerGear;

    public GameObject speedoShower;
    public float minAngle, maxAngle;

    bool lerpToZero;
    float turnResetTime;

    float oldRange;
    float maxSpeed = 12;
    float minSpeed = -1;
    float newRange;

    private void Awake()
    {
        targetRotation = transform.rotation;
        rigid = GetComponent<Rigidbody>();
        currSpeedTarget = currGear * speedPerGear;
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
        targetTurn = dir * turning;
        turnResetTime = Time.time + turnTime;
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
            if(currGear < maxGears)
                currGear++;
        }
        currSpeedTarget = currGear * speedPerGear;
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Lerp(speed, currSpeedTarget, Time.deltaTime * acceleration);
        movement = transform.forward * constantForwardForce;
        BL.motorTorque = speed;
        BR.motorTorque = speed;
        FR.steerAngle = currTurn;
        FL.steerAngle = currTurn;

    }

    private void LateUpdate()
    {
        if (Time.time < turnResetTime)
        {
            currTurn = Mathf.Lerp(currTurn, targetTurn, turnSpeed);
        }
        else
        {
            currTurn = Mathf.Lerp(currTurn, 0, turnSpeed);
            if(currTurn < 1.0f && currTurn > -1.0f)
            {
                currTurn = 0;
            }
        }

        UpdateSpeedo();
    }

    void UpdateSpeedo()
    {

        currSpeed = rigid.velocity.magnitude;
        oldRange = (maxSpeed - minSpeed);
        newRange = (maxAngle - minAngle);
        float val = (((currSpeed - oldRange) * newRange) / oldRange) + maxAngle;

        speedoShower.transform.localRotation = Quaternion.Lerp(speedoShower.transform.localRotation, Quaternion.Euler(new Vector3(0, 0, val)), Time.deltaTime);
    }
}
