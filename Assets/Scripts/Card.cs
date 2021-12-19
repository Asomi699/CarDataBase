using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : DataBaseElement
{
    [SerializeField] private TMP_Text _infoField;
    [SerializeField] private Image _picture;

    private Editor _editor;
    
    private string _info;

    private CarData _data;
    
    private string _uniqProperty;

    public int Id => _data.ID;
    
    public void Init(CarData data, Editor editor)
    {
        _data = data;
        _editor = editor;
        
        _uniqProperty = new AdditionalProperty().GetParameterNameByType(data.UniqProperty);
        
        WriteGeneralData();
        WriteUniqData();
    }

    private void WriteGeneralData()
    {
        _picture.sprite = _data.Icon;
        AddGeneralProperty(_data.ModelLabel + _data.Model);
        AddGeneralProperty(_data.MassLabel + _data.Mass);
        AddGeneralProperty(_data.PowerLabel + _data.Power);
    }
    
    private void AddGeneralProperty(string text)
    {
        _info = _info + text + "\n";
        _infoField.text = _info;
    }
    
    private void WriteUniqData()
    {
        string uniqValue = _data.UniqPropertyValue;
        
        _info = _info + _uniqProperty + uniqValue;
        _infoField.text = _info;
    }
    
    public void OpenEditor()
    {
        _editor.Open(_data.ID);
    }

    public void ReloadData()
    {
        CleanInfo();
        
        _data = App.Data.GetRefCardById(_data.ID);
        
        WriteGeneralData();
        WriteUniqData();
    }
    
    private void CleanInfo()
    {
        _info = "";
        _infoField.text = _info;
    }
}
