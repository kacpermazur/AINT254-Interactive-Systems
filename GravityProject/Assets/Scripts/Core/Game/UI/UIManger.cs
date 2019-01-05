using System.Collections;
using System.Collections.Generic;
using Core.Game;
using UnityEngine;

public class UIManger : MonoBehaviour, IInitializable
{

    [SerializeField] private UIPanelMainMenu _mainMenu;
    [SerializeField] private UIPanelVictory _victoryPanel;

    private List<UIPanel> _uiPanels = new List<UIPanel>();
    
    public void Initialize()
    {
        AddListeners();
        
        _uiPanels.Add(_mainMenu);
        _uiPanels.Add(_victoryPanel);
        
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
        Application.Quit();
    }
    
    private void OnBtnNextStageClicked()
    {
        
    }

    private void OnBtnMainMenuClicked()
    {
        Debug.Log("MainMenu Panel load");
        OpenPanel(_mainMenu);
    }

    private void OpenPanel(UIPanel uiPanel)
    {
        foreach (UIPanel panel in _uiPanels)
        {
            panel.Close();
        }
        
        uiPanel.Open();
    }
    
    
}
