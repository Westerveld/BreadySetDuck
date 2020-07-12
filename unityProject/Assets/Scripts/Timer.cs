using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float totalTime;
    float currTime;
    public CarScript car;

    public TMP_Text timerText;
    bool counting;
    // Start is called before the first frame update
    void Start()
    {
        counting = true;
        currTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!counting)
            return;
        currTime -= Time.deltaTime;
        timerText.text = currTime.ToString("F1");

        if(currTime <= 0)
        {
            counting = false;
            car.GameOver();
        }
    }
}
