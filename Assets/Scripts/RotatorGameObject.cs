using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorGameObject : MonoBehaviour
{
    public int speed=5;

    public bool x_axis;
    public bool y_axis;
    public bool z_axis;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (x_axis) { transform.Rotate(speed * Time.deltaTime, 0, 0);}
        if (y_axis) { transform.Rotate(0, speed * Time.deltaTime, 0);}
        if (z_axis) { transform.Rotate(0, 0, speed * Time.deltaTime);}
    }
}
