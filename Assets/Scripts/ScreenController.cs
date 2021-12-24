using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : DataBaseElement
{
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private DataBaseScreen _dataScreen;

    private List<ScreenBase> _allScreens;

    public void Init()
    {
        _allScreens = new List<ScreenBase>() {_menuScreen, _dataScreen};
    
        _dataScreen.Init();
        
        ShowMenu();
    }
    
    public void ShowMenu()
    {
        HideAllScreens();
        _menuScreen.Show();
    }

    public void ShowData()
    {
        HideAllScreens();
        _dataScreen.Show();
    }

    private void HideAllScreens()
    {
        foreach (var screen in _allScreens)
        {
            screen.Hide();
        }
    }
}
