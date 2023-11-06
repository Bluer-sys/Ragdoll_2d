namespace Game.Gun
{
	using UnityEngine;

	[RequireComponent(typeof(Rigidbody2D))]
	public sealed class Bullet : MonoBehaviour
	{
		[SerializeField] float _speed;
		
		Rigidbody2D _rb;

		void Start()
		{
			_rb = GetComponent<Rigidbody2D>();
			
			Destroy( gameObject, 3f );
		}

		void FixedUpdate()
		{
			_rb.velocity = transform.up * _speed;
		}
	}
}