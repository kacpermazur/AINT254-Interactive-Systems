using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
	public class GUIUpdate : MonoBehaviour
	{
		public Text timerUI;
		public Text deathsUi;

		public void UpdateUI(float time, int deaths)
		{
			timerUI.text = "Time : " + time;
			deathsUi.text = "Deaths : " + deaths;
		}
	}
}
