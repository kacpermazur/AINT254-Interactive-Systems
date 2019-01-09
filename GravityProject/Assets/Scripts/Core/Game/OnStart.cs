using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Game
{
	public class OnStart : MonoBehaviour
	{
		private bool _hasPlayerStarted;

		public bool HasPlayerStarted => _hasPlayerStarted;

		private void OnTriggerEnter(Collider other)
		{
			
			if (other.gameObject.CompareTag("Player"))
			{
				_hasPlayerStarted = false;
			}
			
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				_hasPlayerStarted = true;
			}
		}
	}
}
