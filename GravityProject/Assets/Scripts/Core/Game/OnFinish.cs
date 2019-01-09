using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Game
{
	public class OnFinish : MonoBehaviour
	{
		private bool _hasPlayerFinished;

		public bool HasPlayerFinished
		{
			get { return _hasPlayerFinished; }
			set { _hasPlayerFinished = value; }
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				_hasPlayerFinished = true;
			}
		}
	}
}
