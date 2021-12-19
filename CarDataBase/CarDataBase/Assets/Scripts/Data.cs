using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : DataBaseElement
{
    private CarData[] _base;

    public CarData[] CarDataBase => _base;
    
    public void Init()
    {
        _base = new CarData[] {};
        
        LoadDataFromResources();
        GenerateCardsIDs();
    }
    
    private void LoadDataFromResources()
    {
        _base = Resources.LoadAll<CarData>("CarDataBase");
    }
    
    private void GenerateCardsIDs()
    {
        for (int i = 0; i < _base.Length; i++)
        {
            _base[i].ID = i;
        }
    }

    public ref CarData GetRefCardById(int idCard)
    {
        for (int i = 0; i < _base.Length; i++)
        {
            if (_base[i].ID == idCard)
                return ref _base[i];
        }
        throw new IndexOutOfRangeException("number not found");
    }
}
