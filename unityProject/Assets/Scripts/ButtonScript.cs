using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public float growthRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 growth = new Vector3(Mathf.PingPong(Time.time * growthRate, 0.3f) + 0.5f , Mathf.PingPong(Time.time * growthRate, 0.3f) + 0.5f, transform.position.z);

        transform.localScale = growth;
    }
}
