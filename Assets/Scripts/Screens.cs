using System;
using UnityEngine;

public enum ScreensName
{
    Menu,
    Game,
    Level,
    Settings,
    Market
}

public class Screens : MonoBehaviour
{
    public static Action<ScreensName> OnScreenOpen; 

    [SerializeField] private GameObject _screenMenu;
    [SerializeField] private GameObject _screenLevel;
    [SerializeField] private GameObject _screenGame;
    [SerializeField] private GameObject _screenSettings;
    [SerializeField] private GameObject _screenMarket;

    private GameObject _screenActive;

    private void Start()
    {
        OnScreenOpen += ScreenActive;

        ScreenActive(ScreensName.Menu);
    }

    private void OnDestroy()
    {
        OnScreenOpen -= ScreenActive;
    }

    private void ScreenActive(ScreensName screen)
    {
        if (_screenActive != null) _screenActive.SetActive(false);

        switch (screen)
        {
            case ScreensName.Menu:
                _screenActive = _screenMenu;
                break;
            case ScreensName.Game:
                _screenActive = _screenGame;
                break;
            case ScreensName.Level:
                _screenActive = _screenLevel;
                break;
            case ScreensName.Settings:
                _screenActive = _screenSettings;
                break;
            case ScreensName.Market:
                _screenActive = _screenMarket;
                break;
        }

        _screenActive.SetActive(true);
    }
}
