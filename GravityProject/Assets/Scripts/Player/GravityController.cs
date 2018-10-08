using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{

	public bool IsGravityFlipped = false;
	
	void Update()
	{
		if (Input.GetKey(KeyCode.E) && IsGravityFlipped == false)
		{
			IsGravityFlipped = true;
		}
		else
		{
			IsGravityFlipped = false;
		}
	}

	void FixedUpdate()
	{
		if (IsGravityFlipped == true)
		{
			Physics.gravity *= -1;
			
		}
	}
}
