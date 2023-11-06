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

		void Update()
		{
			_rb.velocity = new Vector2( PlayerInput.Instance.MoveAxis * _speed, _rb.velocity.y );
		}
	}
}