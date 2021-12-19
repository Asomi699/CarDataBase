using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : DataBaseElement
{
    [SerializeField] private Canvas _menuScreen;
    [SerializeField] private Canvas _dataScreen;

    private List<Canvas> _allScreens;

    public void Init()
    {
        _allScreens = new List<Canvas>();
        
        _allScreens.Add(_menuScreen);
        _allScreens.Add(_dataScreen);
        
        _dataScreen.GetComponent<DataBaseScreen>().CreateCards();
        
        ShowMenu();
    }
    
    public void ShowMenu()
    {
        HideAllScreens();
        _menuScreen.GetComponent<IScreen>().Show();
    }

    public void ShowData()
    {
        HideAllScreens();
        _dataScreen.GetComponent<IScreen>().Show();
    }

    private void HideAllScreens()
    {
        foreach (var screen in _allScreens)
        {
            screen.GetComponent<IScreen>().Hide();
        }
    }
}
