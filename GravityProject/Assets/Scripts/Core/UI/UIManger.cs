using System.Collections.Generic;
using Core;
using Core.Audio;
using Core.Game;
using Player;
using UnityEngine;
using UI.Panel;

namespace UI
{
    public class UIManger : MonoBehaviour, IInitializable
    {

        [SerializeField] private UIPanelMainMenu _mainMenu;
        [SerializeField] private UIPanelVictory _victoryPanel;
        [SerializeField] private UIPanelInGame _inGamePanel;
        [SerializeField] private UIPanelPaused _pausedPanel;

        public UIPanelMainMenu MainMenuPanel => _mainMenu;
        public UIPanelVictory VictoryPanel => _victoryPanel;
        public UIPanelInGame InGamePanel => _inGamePanel;
        public UIPanelPaused PausedPanel => _pausedPanel;

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
            PlaySound();
            OpenPanel(_inGamePanel);
            GameManger.instance.SetGameState(GameManger.GameState.INGAME);
            GameManger.instance.PlayerManger.PlayerController.CanShoot(true);
        }

        private void OnBtnExitClicked()
        {
            PlaySound();
            Application.Quit();
        }

        private void OnBtnNextStageClicked()
        {
            //
        }

        private void OnBtnMainMenuClicked()
        {
            PlaySound();
            GameManger.instance.SetGameState(GameManger.GameState.START);
        }

        private void PlaySound()
        {
            GameManger.instance.SoundManger.PlaySound("btnClick", SoundManger.SoundType.UI);
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
}
