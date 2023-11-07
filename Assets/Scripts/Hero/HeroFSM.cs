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
		
		public EHeroState Current { get; private set; }

		
		void Start()
		{
			_heroGun = GetComponent<HeroGun>();
			
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
			switch (Current)
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
			switch (Current)
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
			bool isDefault			= Current == EHeroState.Default;
			bool isAiming			= Current == EHeroState.Aiming;
			bool hasGun				= _heroGun.HasGun();
			
			if( isDefault && hasGun )
				Enter( EHeroState.Aiming );
			
			if( isAiming )
				Enter( EHeroState.Default );
		}

		void OnGrab()
		{
			bool isAiming			= Current == EHeroState.Aiming;

			if( isAiming )
				Enter( EHeroState.Default );
		}
		
		void Enter(EHeroState state)
		{
			if ( Current == state )
				throw new Exception($"Hero is already in {state} state");
				
			Current = state;
			Debug.Log( $"State: {Current}" );
			OnEnter();
		}

		void ForAllHands(Action<HeroLimbIK> action)		=> _handsIk.ForEach( action );

		void ResetShootTimer()							=> _shotTimer = _shootInterval;
	}
}