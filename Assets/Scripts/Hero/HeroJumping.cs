namespace Game.Hero
{
	using UnityEngine;

	public sealed class HeroJumping : MonoBehaviour
	{
		[Header("Settings")]
		[SerializeField] float			_jumpForce;
		[SerializeField] float			_jumpDelay;
		
		[Header("Refs")]
		[SerializeField] Rigidbody2D	_rb;

		float _jumpTimer;
		
		void Update()
		{
			if ( Input.GetKeyDown( KeyCode.Space ) && _jumpTimer == 0 )
			{
				Jump();
				_jumpTimer = _jumpDelay;
			}

			_jumpTimer = Mathf.Clamp( _jumpTimer - Time.deltaTime, 0, _jumpDelay );
		}

		void Jump()
		{
			_rb.AddForce( Vector2.up * _jumpForce, ForceMode2D.Impulse );
		}
	}
}