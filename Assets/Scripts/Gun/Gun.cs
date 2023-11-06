namespace Game.Gun
{
	using UnityEngine;

	[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
	public sealed class Gun : MonoBehaviour
	{
		[SerializeField] Bullet _bulletPrefab;
		[SerializeField] Transform _muzzle;
		
		Rigidbody2D _rb;
		Collider2D	_collider;
		
		void Start()
		{
			_rb			= GetComponent<Rigidbody2D>();
			_collider	= GetComponent<Collider2D>();
		}

		
		public void Throw()
		{
			transform.SetParent( null );
			
			SetIsKinematic( false );
			SetColliderIsActive( true );
			
			_rb.AddForce( Vector2.right * 2f, ForceMode2D.Impulse );	
			_rb.AddTorque( 7f, ForceMode2D.Impulse);	
		}

		public void Attach(Transform parent)
		{
			SetIsKinematic( true );
			SetColliderIsActive( false );
			
			transform.SetParent( parent );
			transform.localPosition = Vector2.zero;
		}

		public void Shoot()
		{
			Bullet bullet = Instantiate( 
				_bulletPrefab, 
				_muzzle.position, 
				Quaternion.identity
			);

			bullet.transform.up = _muzzle.right;
		}
		
		
		void SetIsKinematic(bool state)
		{
			_rb.isKinematic = state;
			
			_rb.collisionDetectionMode = state 
				? CollisionDetectionMode2D.Discrete 
				: CollisionDetectionMode2D.Continuous;
		}

		void SetColliderIsActive(bool state)
		{
			_collider.enabled = state;
		}
	}
}