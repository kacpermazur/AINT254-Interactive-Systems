using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Panel
{
	public class UIPanelPaused : UIPanel
	{
		public UnityAction okButtonClicked;
		public UnityAction mainMenuButtonClicked;

		[SerializeField] private Text _currentStage;

		[SerializeField] private Button _ok;
		[SerializeField] private Button _mainMenu;

		public override void Initialize()
		{
			_ok.onClick.AddListener(BtnOk);
			_mainMenu.onClick.AddListener(BtnMainMenu);
		}

		private void BtnOk()
		{
			okButtonClicked?.Invoke();
		}

		private void BtnMainMenu()
		{
			mainMenuButtonClicked?.Invoke();
		}

		public void CurrentStage(int stage)
		{
			_currentStage.text = "You are currently on Stage " + stage;
		}
	}
}