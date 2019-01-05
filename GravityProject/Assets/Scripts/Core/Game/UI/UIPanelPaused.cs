using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIPanelPaused : UIPanel
{
	public UnityAction okButtonClicked;
	public UnityAction socreboardButtonClicked;
	public UnityAction mainMenuButtonClicked;

	[SerializeField] private Text _currentStage;

	[SerializeField] private Button _ok;
	[SerializeField] private Button _scoreboard;
	[SerializeField] private Button _mainMenu;

	public override void Initialize()
	{
		_ok.onClick.AddListener(BtnOk);
		//_scoreboard.onClick.AddListener();
		//_mainMenu.onClick.AddListener();
	}

	private void BtnOk()
	{
		okButtonClicked?.Invoke();
	}

	private void BtnScoreboard()
	{
		
	}
}
