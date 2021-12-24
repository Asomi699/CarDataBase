using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Car", menuName = "CarData/Bus")]
public class BusCar : CarBase
{
    [SerializeField] private int _numberSeats;

    public override string GetUniqValue()
    {
        return _numberSeats.ToString();
    }
    
    public override void SetUniqValue(string value)
    {
        _numberSeats = Convert.ToInt32(value);
    }
}
