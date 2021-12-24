
using System;
using System.Collections.Generic;
using UnityEngine;

public class CarType 
{
    public string GetLabelByType(CarBase car)
    {
        switch (car)
        {
            case SportCar sportCar:
                return "Speed ";
            
            case DailyCar dailyCar:
                return "Color ";
            
            case TruckCar truckCar:
                return "Lifting Capacity ";
            
            case BusCar busCar:
                return "Number Seats ";
        }
        throw new Exception("No matches found");
    }
}


