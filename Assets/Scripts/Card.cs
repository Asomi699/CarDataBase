using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : DataBaseElement
{
    [SerializeField] private TMP_Text _infoField;
    [SerializeField] private Image _picture;

    private CarBase _data;
    
    private string _info;

    private string _uniqProperty;

    private string _modelLabel = "Model ";
    private string _massLabel = "Mass ";
    private string _powerLabel = "Power ";
    
    private Editor _editor;
    
    public int Id => _data.ID;
    
    public void Init(CarBase data, Editor editor)
    {
        _data = data;
        _editor = editor;

        _uniqProperty = new CarType().GetLabelByType(data);
        
        WriteGeneralData();
        WriteUniqData();
    }

    private void WriteGeneralData()
    {
        _picture.sprite = _data.Icon;
        AddGeneralProperty(_modelLabel + _data.Model);
        AddGeneralProperty(_massLabel + _data.Mass);
        AddGeneralProperty(_powerLabel + _data.Power);
    }
    
    private void AddGeneralProperty(string text)
    {
        _info = _info + text + "\n";
        _infoField.text = _info;
    }
    
    private void WriteUniqData()
    {
        string uniqValue = _data.GetUniqValue();
        
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
