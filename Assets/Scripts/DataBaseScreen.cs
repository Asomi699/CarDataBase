using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class DataBaseScreen : DataBaseElement, IScreen
{
    [SerializeField] private Application _app;
    [SerializeField] private GameObject _cardTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private Editor _editMenu;

    private GameObject[] _createdCard;

    private void OnEnable()
    {
        _editMenu.CardChanged += OnUpdateCard;
    }
    
    private void OnDisable()
    {
        _editMenu.CardChanged -= OnUpdateCard;
    }

    public void Init()
    {
        CreateCards();
    }

    public void CreateCards()
    {
        CarData[] carDataBase = _app.Data.CarDataBase;
        _createdCard = new GameObject[carDataBase.Length];
        
        for (int i = 0; i < carDataBase.Length; i++)
        {
            var card = Instantiate(_cardTemplate, _container);
            card.GetComponent<Card>().Init(carDataBase[i], _editMenu);

            _createdCard[i] = card;
        }
    }

    public void OnUpdateCard(int cardId)
    {
        for (int i = 0; i < _createdCard.Length; i++)
        {
            if (_createdCard[i].GetComponent<Card>().Id == cardId)
            {
                _createdCard[i].GetComponent<Card>().ReloadData();
            }
        }
    }
    
    public void Show()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().interactable = true;
    }

    public void Hide()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().interactable = false;
    }
}
