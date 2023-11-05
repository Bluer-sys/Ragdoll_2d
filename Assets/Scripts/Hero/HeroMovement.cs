namespace Game.Hero
{
	using Game.Input;
	using UnityEngine;

	public sealed class HeroMovement : MonoBehaviour
	{
		[Header( "Settings" )]
		[SerializeField] float _speed;
		
		[Header( "Refs" )] 
		[SerializeField] Rigidbody2D _rb;
		[SerializeField] PlayerInput _input;

		void Update()
		{
			_rb.velocity = new Vector2( _input.MoveAxis * _speed, _rb.velocity.y );
		}
	}
}