using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Car", menuName = "CarData/Truck")]
public class TruckCar : CarBase
{
    [SerializeField] private int _liftingCapacity;

    public override string GetUniqValue()
    {
        return _liftingCapacity.ToString();
    }
    
    public override void SetUniqValue(string value)
    {
        _liftingCapacity = Convert.ToInt32(value);
    }
}
