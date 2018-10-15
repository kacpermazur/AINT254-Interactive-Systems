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
            Physics.gravity *= -1;

        }
		else
		{
			IsGravityFlipped = false;
		}
	}
}
