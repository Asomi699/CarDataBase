using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Editor : DataBaseElement
{
    [SerializeField] private GameObject _content;
    
    [SerializeField] private TMP_InputField _model;
    [SerializeField] private TMP_InputField _mass;
    [SerializeField] private TMP_InputField _power;
    [SerializeField] private TMP_InputField _uniqProperty;
    
    [SerializeField] private TMP_Text _modelLabel;
    [SerializeField] private TMP_Text _massLabel;
    [SerializeField] private TMP_Text _powerLabel;
    [SerializeField] private TMP_Text _uniqPropertyLabel;

    private CarBase _card;

    public event UnityAction<int> CardChanged;
    
    public void Open(int cardID)
    {
        _card =  App.Data.GetRefCardById(cardID);
        
        Open();
        FillFields();
    }

    private void Open()
    {
        _content.SetActive(true); 
    }
    
    public void Close()
    {
        _content.SetActive(false);
    }

    private void FillFields()
    {
        _modelLabel.text = "Model ";
        _massLabel.text = "Mass ";
        _powerLabel.text = "Power ";
        
        _model.text = _card.Model;
        _mass.text = _card.Mass;
        _power.text = _card.Power;
        
        CarType property = new CarType();

        _uniqPropertyLabel.text = property.GetLabelByType(_card);
        _uniqProperty.text = _card.GetUniqValue();
    }

    public void SaveData()
    {
        WrireNewDataToInfo();
        WriteNewDataToBase();
        
        CardChanged?.Invoke(_card.ID);
        
        Close();
    }

    private void WrireNewDataToInfo()
    {
        _card.Model = _model.text;
        _card.Mass = _mass.text;
        _card.Power = _power.text;
        
        _card.SetUniqValue( _uniqProperty.text); 
    }

    private void WriteNewDataToBase()
    {
        var card = App.Data.GetRefCardById(_card.ID);
        
        card.Model = _model.text;
        card.Mass = _mass.text;
        card.Power = _power.text;
        card.SetUniqValue(_uniqProperty.text);
        
        card.Save();
    }
}
