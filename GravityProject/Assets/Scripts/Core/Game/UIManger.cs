using System.Collections;
using System.Collections.Generic;
using Core.Game;
using UnityEngine;

public class UIManger : MonoBehaviour, IInitializable
{

    [SerializeField] private UIPanelMainMenu _mainMenu;
    [SerializeField] private UIPanelVictory _victoryPanel;

    private List<UIPanel> _UiPanels;
    
    public void Initialize()
    {
        AddListeners();
        
        _UiPanels.Add(_mainMenu);
        _UiPanels.Add(_victoryPanel);
        
        _victoryPanel.Initialize();
        _mainMenu.Initialize();
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
    }

    private void RemoveListeners()
    {
        _victoryPanel.onBtnMainMenuClicked -= OnBtnMainMenuClicked;
        _victoryPanel.onBtnNextStageClicked -= OnBtnNextStageClicked;
        
        _mainMenu.onBtnStartClicked -= OnBtnStartClicked;
        _mainMenu.onBtnExitClicked -= OnBtnExitClicked;
    }
    
    private void OnBtnStartClicked()
    {
        
    }
    
    private void OnBtnExitClicked()
    {
        
    }
    
    private void OnBtnNextStageClicked()
    {
        
    }

    private void OnBtnMainMenuClicked()
    {
        OpenPanel(_mainMenu);
    }

    private void OpenPanel(UIPanel uiPanel)
    {
        foreach (UIPanel panel in _UiPanels)
        {
            panel.Close();
        }
        
        uiPanel.Open();
    }
    
}
