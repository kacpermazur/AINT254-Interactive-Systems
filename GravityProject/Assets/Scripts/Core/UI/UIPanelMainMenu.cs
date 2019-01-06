using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Panel
{
    public class UIPanelMainMenu : UIPanel
    {
        public UnityAction onBtnStartClicked;
        public UnityAction onBtnExitClicked;
        
        [SerializeField] private Button _start;
        [SerializeField] private Button _exit;

        public override void Initialize()
        {
            _start.onClick.AddListener(BtnStart);
            _exit.onClick.AddListener(BtnExit);
        }

        private void BtnStart()
        {
            onBtnStartClicked?.Invoke();
        }
        
        private void BtnExit()
        {
            onBtnExitClicked?.Invoke();
        }
        
    }
}