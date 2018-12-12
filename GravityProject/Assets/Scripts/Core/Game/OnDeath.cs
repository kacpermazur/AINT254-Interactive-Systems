using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Game
{
	public class OnDeath : MonoBehaviour
	{

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				GameManger.SetPlayerDied = true;
			}

		}
	}
}
