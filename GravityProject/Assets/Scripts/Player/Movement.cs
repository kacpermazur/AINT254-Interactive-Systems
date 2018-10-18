using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

public class Movement : MonoBehaviour
{
	// Player Mondifier Values
	public float MoveSpeed = 1f;
	public float RotSpeed = 1f;
	public float JumpForce = 1f;
	
	// Input Values
	private float _horizontal;
	private float _vertical;
	private float _jump;
	
	private Rigidbody _playerRb;
    
	
	void Start ()
	{
		_playerRb = GetComponent<Rigidbody>();
	}
	
	
	void Update ()
	{
		PlayerControls();
		
	}


	private void PlayerControls()
	{
		_horizontal = Input.GetAxisRaw("Horizontal");
		_vertical = Input.GetAxisRaw("Vertical");
		_jump = Input.GetAxisRaw("Jump");
		
		transform.Translate(0,0, _vertical * MoveSpeed * Time.deltaTime);
		transform.Rotate(0, _horizontal * RotSpeed * Time.deltaTime, 0);

		if (_jump == 1 && IsGrounded())
		{
			_playerRb.AddForce(Vector3.up * JumpForce * Time.deltaTime);
		}
	}
	
	// Distance From Ground To Player From Their Local Down To Check If They In Air
	private bool IsGrounded()
	{
		RaycastHit distanceRay;
		Ray downwardRay = new Ray(transform.position, -transform.up);

		Physics.Raycast(downwardRay, out distanceRay);
		
		//Debug.Log(distanceRay.distance);

		// Above Standing Distance or 0 If Ray Doest Hit Any Surface
		if (distanceRay.distance < 1.1f && distanceRay.distance != 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
