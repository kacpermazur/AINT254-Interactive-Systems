using UnityEngine;
using Player;

public class AttractTo : MonoBehaviour
{
    [SerializeField] private float _minDistance;

	private Rigidbody _object;
	
	private Transform _playerTransform;
	private Rigidbody _playerRigidbody;
	
	private Vector3 _direction;
	private float _distance;
	private float _force;
	
	
	void Start ()
	{
		_playerTransform = PlayerManager.PlayerTransform;
		_playerRigidbody = PlayerManager.PlayerRigidbody;

		_object = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
        DistanceCheck();

        if(_distance < _minDistance)
        {
            AttractToObject();
        }
	}

    private void DistanceCheck()
    {
        _direction = _object.position - _playerTransform.position;
        _distance = _direction.magnitude;
    }

	private void AttractToObject()
	{
		_force = (_object.mass * _playerRigidbody.mass);
		_playerRigidbody.AddForce(_direction.normalized * _force);
	}
}
