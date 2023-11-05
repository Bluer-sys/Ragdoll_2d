namespace Game.Hero
{
	using UnityEngine;

	public sealed class HeroMovement : MonoBehaviour
	{
		[Header( "Settings" )]
		[SerializeField] float _speed;
		
		[Header( "Refs" )] 
		[SerializeField] Rigidbody2D _rb;

		void Update()
		{
			_rb.velocity = new Vector2( Input.GetAxis( "Horizontal" ) * _speed, _rb.velocity.y );
		}
	}
}