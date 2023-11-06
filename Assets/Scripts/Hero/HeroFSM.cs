namespace Game.Hero
{
	using System;
	using Game.Input;
	using UnityEngine;

	public enum EHeroState
	{
		None,
		
		Default,
		Aiming
	}
	
	[RequireComponent(typeof(HeroGun))]
	public sealed class HeroFSM : MonoBehaviour
	{
		[Header( "Settings" )] 
		[SerializeField] float	_shootInterval;
		
		[Header("Refs")]
		[SerializeField] PlayerInput	_input;
		
		HeroGun		_heroGun;
		
		float		_shotTimer;
		
		public EHeroState Current { get; private set; }

		
		void Start()
		{
			_heroGun = GetComponent<HeroGun>();
			
			Enter( EHeroState.Default );
		}

		
		void OnEnable()
		{
			_input.OnAim.AddListener( OnAim );
			_input.OnGrab.AddListener( OnGrab );
		}

		void OnDisable()
		{
			_input.OnAim.RemoveListener( OnAim );
			_input.OnGrab.RemoveListener( OnGrab );
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
					break;
				
				case EHeroState.Aiming:
					ResetShootTimer();
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

		void ResetShootTimer()	=> _shotTimer = _shootInterval;
	}
}