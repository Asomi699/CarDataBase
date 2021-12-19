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

    private CarData _card;

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
        _modelLabel.text = _card.ModelLabel;
        _massLabel.text = _card.MassLabel;
        _powerLabel.text = _card.PowerLabel;
        
        _model.text = _card.Model;
        _mass.text = _card.Mass;
        _power.text = _card.Power;
        
        AdditionalProperty property = new AdditionalProperty();

        _uniqPropertyLabel.text = property.GetParameterNameByType(_card.UniqProperty);
        _uniqProperty.text = _card.UniqPropertyValue;
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
        _card.UniqPropertyValue = _uniqProperty.text;
    }

    private void WriteNewDataToBase()
    {
        var card = App.Data.GetRefCardById(_card.ID);
        
        card.Model = _model.text;
        card.Mass = _mass.text;
        card.Power = _power.text;
        card.UniqPropertyValue = _uniqProperty.text;
        
        card.Save();
    }
}
