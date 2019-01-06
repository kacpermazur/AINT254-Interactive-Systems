using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Game;
using UnityEngine;

public class UIManger : MonoBehaviour, IInitializable
{
    
    [SerializeField] private UIPanelMainMenu _mainMenu;
    [SerializeField] private UIPanelVictory _victoryPanel;
    [SerializeField] private UIPanelInGame _inGamePanel;
    [SerializeField] private UIPanelPaused _pausedPanel;
    
    public UIPanelMainMenu MainMenu { get { return _mainMenu; } }
    public UIPanelVictory VictoryPanel { get { return _victoryPanel; } }
    public UIPanelInGame InGamePanel { get { return _inGamePanel; } }
    public UIPanelPaused PausedPanel{ get { return _pausedPanel; } }

    private List<UIPanel> _uiPanels = new List<UIPanel>();

    public void Initialize()
    {
        AddListeners();
        
        _uiPanels.Add(_mainMenu);
        _uiPanels.Add(_victoryPanel);
        _uiPanels.Add(_inGamePanel);
        _uiPanels.Add(_pausedPanel);
        
        _victoryPanel.Initialize();
        _mainMenu.Initialize();
        _pausedPanel.Initialize();
    }

    private void OnDestroy()
    {
        RemoveListeners();
    }
    
    private void AddListeners()
    {
        _victoryPanel.onBtnMainMenuClicked += OnBtnMainMenuClicked;
        _victoryPanel.onBtnNextStageClicked += OnBtnNextStageClicked;
        
        _mainMenu.onBtnStartClicked += OnBtnStartClicked;
        _mainMenu.onBtnExitClicked += OnBtnExitClicked;

        _pausedPanel.okButtonClicked += OnBtnStartClicked;
        _pausedPanel.mainMenuButtonClicked += OnBtnMainMenuClicked;
    }

    private void RemoveListeners()
    {
        _victoryPanel.onBtnMainMenuClicked -= OnBtnMainMenuClicked;
        _victoryPanel.onBtnNextStageClicked -= OnBtnNextStageClicked;
        
        _mainMenu.onBtnStartClicked -= OnBtnStartClicked;
        _mainMenu.onBtnExitClicked -= OnBtnExitClicked;
        
        _pausedPanel.okButtonClicked -= OnBtnStartClicked;
        _pausedPanel.mainMenuButtonClicked -= OnBtnMainMenuClicked;
    }
    
    private void OnBtnStartClicked()
    {
        OpenPanel(_inGamePanel);
        GameManger.instance.SetGameState(GameManger.GameState.INGAME);
    }
    
    private void OnBtnExitClicked()
    {
        Application.Quit();
    }
    
    private void OnBtnNextStageClicked()
    {
        //
    }

    private void OnBtnMainMenuClicked()
    {
        OpenPanel(_mainMenu);
        GameManger.instance.SetGameState(GameManger.GameState.START);
    }

    public void OpenPanel(UIPanel uiPanel)
    {
        foreach (UIPanel panel in _uiPanels)
        {
            panel.Close();
        }
        
        uiPanel.Open();
    }
    
    
}
