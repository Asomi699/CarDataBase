using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Car", menuName = "CarData/DailyCar")]
public class DailyCar : CarBase
{
    [SerializeField] private string _color;
    
    public override string GetUniqValue()
    {
        return _color;
    }

    public override void SetUniqValue(string value)
    {
        _color = value;
    }
}
