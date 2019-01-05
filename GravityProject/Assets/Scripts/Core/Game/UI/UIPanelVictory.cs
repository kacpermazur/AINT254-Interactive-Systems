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
            Debug.Log("Invoked");
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
            int d = (int)(time * 100.0f);
            
            int minutes = d / (60 * 100);
            int seconds = (d % (60 * 100)) / 100;
            
            return String.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}