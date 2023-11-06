namespace Game.Hero
{
	using Game.Gun;
	using Game.Input;
	using UnityEngine;

	public sealed class HeroGun : MonoBehaviour
	{
		[SerializeField] float			_gunRotationOffset;
		[SerializeField] Transform		_rightArm;
		[SerializeField] Transform		_leftArm;
		[SerializeField] PlayerInput	_input;

		Gun _current;
		
		
		void OnEnable()		=> _input.OnGrab.AddListener( OnGrab );
		void OnDisable()	=> _input.OnGrab.RemoveListener( OnGrab );


		public void Shoot()		=> _current.Shoot();
		
		public bool HasGun()	=> _current != null;
		

		void OnGrab()
		{
			if ( _current != null )
			{
				_current.Throw();
				_current = null;
			}
			else
			{
				Collider2D col = Physics2D.OverlapCircle( 
					_rightArm.position, 
					5, 
					LayerMask.GetMask( "Gun" ) 
				);

				if(
					col != null										&& 
					col.transform.TryGetComponent( out Gun gun )
					)
				{
					gun.Attach( _rightArm );
					gun.transform.localRotation = Quaternion.Euler( 0, 0, _gunRotationOffset );

					_current = gun;
				}
			}
		}
	}
}