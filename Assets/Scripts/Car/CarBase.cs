using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
public abstract class CarBase : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _model;
    [SerializeField] private string _mass;
    [SerializeField] private string _power;

    protected int _id;

    public Sprite Icon 
    {
        get => _icon;
    }

    public string Model
    {
        get => _model;
        set => _model = value;
    }

    public string Mass
    {
        get => _mass;
        set => _mass = value;
    }

    public string Power
    {
        get => _power;
        set => _power = value;
    }

    public int ID
    {
        get => _id;
        set => _id = value;
    }

    public abstract string GetUniqValue();

    public abstract void SetUniqValue(string value);
    
    public void Save()
    {
    #if UNITY_EDITOR
        EditorUtility.SetDirty(this);
    #endif
    }
}
