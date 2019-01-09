using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panel
{
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
			_deathText.text = "Deaths: " + count;
		}
		
		private string FormatTime(float time)
		{
			int seconds = (int) (time % 60);
			int minutes = (int) (time / 60) % 60;
				
			return String.Format("{0:00}:{1:00}", minutes, seconds);
		}
	}
}