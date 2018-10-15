using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractTo : MonoBehaviour
{

    [SerializeField]
    private GameObject _playerPos;
    private Rigidbody _object;

    [SerializeField]
    private float _minDistance;

    // Attract Properties
	private Vector3 _direction;
	private float _distance;
	private float _force;
	
	// mass1 * mass2 / distance
	
	// Use this for initialization
	void Start ()
	{
		_object = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
        DistanceCheck();

        //Debug.Log(_distance);

        if(_distance < _minDistance)
        {
            AttractToObject();
        }
	}

    private void DistanceCheck()
    {
        // Distance from BlackHole To Player
        _direction = _object.position - _playerPos.transform.position;
        _distance = _direction.magnitude;
    }

	private void AttractToObject()
	{
		// Mass Of Two Obj To Get Force
		_force = (_object.mass * _playerPos.GetComponent<Rigidbody>().mass);
		
		//Same Direction Towards Obj 
		_playerPos.GetComponent<Rigidbody>().AddForce(_direction.normalized * _force);
	}
}
