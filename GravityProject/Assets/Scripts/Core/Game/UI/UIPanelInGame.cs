using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIPanelInGame : UIPanel
{
	[SerializeField] private Text _timeText;
	[SerializeField] private Text _deathText;

	public void changeTimeText(float time)
	{
		_timeText.text = "Time : " + FormatTime(time);
	}
	
	public void changeDeathText(int count)
	{
		_timeText.text = "Time : " + count;
	}
	
	private string FormatTime(float time)
	{
		int d = (int)(time * 100.0f);
            
		int minutes = d / (60 * 100);
		int seconds = (d % (60 * 100)) / 100;
            
		return String.Format("{0:00}:{1:00}", minutes, seconds);
	}
}
