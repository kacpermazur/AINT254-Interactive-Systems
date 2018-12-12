using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Game
{
	public class OnStart : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				GameManger.SetPlayerStarted = false;
			}
			
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				GameManger.SetPlayerStarted = true;
			}
		}
	}
}
