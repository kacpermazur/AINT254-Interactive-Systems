using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Game
{
	public class OnFinish : MonoBehaviour
	{
		private bool _hasPlayerFinished;

		public bool HasPlayerFinished => _hasPlayerFinished;

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				_hasPlayerFinished = true;
			}
		}
	}
}
