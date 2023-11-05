namespace Game.Hero
{
	using System;
	using Game.Input;
	using UnityEngine;

	public sealed class HeroJumping : MonoBehaviour
	{
		[Header("Settings")]
		[SerializeField] float			_jumpForce;
		[SerializeField] float			_jumpDelay;
		
		[Header("Refs")]
		[SerializeField] Rigidbody2D	_rb;
		[SerializeField] PlayerInput	_input;

		float _jumpTimer;

		void OnEnable()
		{
			_input.OnJump.AddListener( TryJump );
		}

		void OnDisable()
		{
			_input.OnJump.RemoveListener( TryJump );
		}

		void Update()
		{
			_jumpTimer = Mathf.Clamp( _jumpTimer - Time.deltaTime, 0, _jumpDelay );
		}

		
		void TryJump()
		{
			if ( _jumpTimer > 0 )
				return;
			
			_rb.AddForce( Vector2.up * _jumpForce, ForceMode2D.Impulse );
			_jumpTimer = _jumpDelay;
		}
	}
}