namespace DefaultNamespace
{
	using UnityEngine;

	[RequireComponent(typeof(Rigidbody2D))]
	public sealed class HeroBalance : MonoBehaviour
	{
		[SerializeField] float	_targetRotation;
		[SerializeField] float	_force;
		
		Rigidbody2D		_rb;
		float			_targetAngle;
		
		void Start()
		{
			_rb = GetComponent<Rigidbody2D>();
		}

		void Update()
		{
			_targetAngle = Mathf.LerpAngle( _rb.rotation, _targetRotation, _force * Time.deltaTime );
		}

		void FixedUpdate()
		{
			_rb.MoveRotation( _targetAngle );
		}
	}
}