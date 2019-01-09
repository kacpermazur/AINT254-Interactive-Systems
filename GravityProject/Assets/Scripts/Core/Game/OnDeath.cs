using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Game
{
	public class OnDeath : MonoBehaviour
	{
		private bool _hasPlayerDied;

		public bool HasPlayerDied => _hasPlayerDied;

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				_hasPlayerDied = true;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				_hasPlayerDied = false;
			}
		}
	}
}
