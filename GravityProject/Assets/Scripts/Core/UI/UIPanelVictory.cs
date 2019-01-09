using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Panel
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

        public void TextBestTime(float time)
        {
            _bestTime.text = ("Best Time Was: " + FormatTime(time));
        }

        public void TextPlayerTime(float time)
        {
            _playerTime.text = ("Your Time Was: " + FormatTime(time));
        }
        
        private string FormatTime(float time)
        {
            int seconds = (int) (time % 60);
            int minutes = (int) (time / 60) % 60;
				
            return String.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
