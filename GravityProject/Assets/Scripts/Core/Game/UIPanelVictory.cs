using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core.Game
{
    public class UIPanelVictory : UIPanel
    {
        public UnityAction onBtnNextStageClicked;
        public UnityAction onBtnMainMenuClicked;
        
        [SerializeField] private Text _bestTime;
        [SerializeField] private Text _playerTime;

        [SerializeField] private Button _nextStage;
        [SerializeField] private Button _mainMenu;

        public override void Initialize()
        {
            _nextStage.onClick.AddListener(BtnNextStage);
            _mainMenu.onClick.AddListener(BtnMainMenu);
        }

        private void BtnNextStage()
        {
            onBtnNextStageClicked?.Invoke();
        }

        private void BtnMainMenu()
        {
            onBtnMainMenuClicked?.Invoke();
        }
    }
}