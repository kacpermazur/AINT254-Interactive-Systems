using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class destoryBulletCol : MonoBehaviour
{
	private bool _hasEnteredOnDeath;
	
	public bool hasEntered{ get { return _hasEnteredOnDeath; }}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			_hasEnteredOnDeath = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			_hasEnteredOnDeath = false;
		}
	}


}
