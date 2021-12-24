using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseElement : MonoBehaviour
{
    public Application App { get { return GameObject.FindObjectOfType<Application>(); }}
}

public class Application : MonoBehaviour
{
    [SerializeField] private Data _data;
    [SerializeField] private ScreenController _screenController;
    
    public Data Data => _data;

    private void Start()
    {
        StartCoroutine(Initialize());
    }

    IEnumerator Initialize()
    {
        _data.Init();
        yield return null;
        _screenController.Init();
    }
}



