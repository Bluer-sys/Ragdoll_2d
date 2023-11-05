namespace Game.Hero
{
	using Game.Input;
	using UnityEngine;

	[RequireComponent(typeof(Animator))]
	public sealed class HeroWalkAnimation : MonoBehaviour
	{
		static readonly int IsMoving = Animator.StringToHash( "IsWalking" );

		[SerializeField] PlayerInput _input;
			
		Animator _animator;

		void Start()
		{
			_animator = GetComponent<Animator>();
		}

		void Update()
		{
			_animator.SetBool( IsMoving, _input.MoveAxis != 0 );
		}
	}
}