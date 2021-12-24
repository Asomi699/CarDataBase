using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Car", menuName = "CarData/SportCar")]
public class SportCar : CarBase
{
    [SerializeField] private int _speed;
    
    public override string GetUniqValue()
    {
        return _speed.ToString();
    }
    
    public override void SetUniqValue(string value)
    {
        _speed = Convert.ToInt32(value);
    }
}
