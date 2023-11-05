namespace Game.Hero
{
	using Game.Input;
	using UnityEngine;

	[RequireComponent(typeof(Animator))]
	public sealed class HeroWalkAnimation : MonoBehaviour
	{
		static readonly int IsMoving	= Animator.StringToHash( "IsWalking" );
		static readonly int AnimSpeed	= Animator.StringToHash( "AnimSpeed" );

		[Header( "Settings" )] 
		[SerializeField] float _animSpeed;
		
		[Header("Refs")]
		[SerializeField] PlayerInput _input;
			
		Animator _animator;

		void Start()
		{
			_animator = GetComponent<Animator>();
			
			_animator.SetFloat( AnimSpeed, _animSpeed );
		}

		void Update()
		{
			_animator.SetBool( IsMoving, _input.MoveAxis != 0 );
		}
	}
}