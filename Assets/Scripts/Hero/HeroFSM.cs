namespace Game.Hero
{
	using System;
	using System.Collections.Generic;
	using Game.Input;
	using UnityEngine;

	public enum EHeroState
	{
		None,
		
		Default,
		Aiming
	}
	
	public sealed class HeroFSM : MonoBehaviour
	{
		[Header( "Settings" )] 
		[SerializeField] float	_shootInterval;

		[Header("Refs")]
		[SerializeField] HeroGun			_heroGun;
		[SerializeField] List<HeroLimbIK>	_handsIk;
		
		float		_shotTimer;
		EHeroState	_current;

		
		void Start()
		{
			Enter( EHeroState.Default );
		}

		
		void OnEnable()
		{
			PlayerInput.Instance.OnAim.AddListener( OnAim );
			PlayerInput.Instance.OnGrab.AddListener( OnGrab );
		}

		void OnDisable()
		{
			PlayerInput.Instance.OnAim.RemoveListener( OnAim );
			PlayerInput.Instance.OnGrab.RemoveListener( OnGrab );
		}
		

		void Update()
		{
			switch (_current)
			{
				case EHeroState.Default:
					
					break;
				
				case EHeroState.Aiming:
					_shotTimer -= Time.deltaTime;

					if ( _shotTimer <= 0 )
					{
						_heroGun.Shoot();
						ResetShootTimer();
					}
					break;
			}
		}


		void OnEnter()
		{
			switch (_current)
			{
				case EHeroState.Default:
					ForAllHands( h => h.SetEnabled( false ) );
					break;
				
				case EHeroState.Aiming:
					ResetShootTimer();
					ForAllHands( h => h.SetEnabled( true ) );
					break;
			}
		}

		void OnAim()
		{
			bool isDefault			= _current == EHeroState.Default;
			bool isAiming			= _current == EHeroState.Aiming;
			bool hasGun				= _heroGun.HasGun();
			
			if( isDefault && hasGun )
				Enter( EHeroState.Aiming );
			
			if( isAiming )
				Enter( EHeroState.Default );
		}

		void OnGrab()
		{
			bool isAiming			= _current == EHeroState.Aiming;

			if( isAiming )
				Enter( EHeroState.Default );
		}
		
		void Enter(EHeroState state)
		{
			if ( _current == state )
				throw new Exception($"Hero is already in {state} state");
				
			_current = state;
			
			Debug.Log( $"State Entered: {_current}" );
			
			OnEnter();
		}

		void ForAllHands(Action<HeroLimbIK> action)		=> _handsIk.ForEach( action );

		void ResetShootTimer()							=> _shotTimer = _shootInterval;
	}
}