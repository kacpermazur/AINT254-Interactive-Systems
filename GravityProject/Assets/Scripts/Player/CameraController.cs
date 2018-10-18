using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private GameObject _player;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_player.GetComponent<GravityController>().IsGravityFlipped == true)
		{
			transform.Rotate(180,0,0);
		}
	}
}
