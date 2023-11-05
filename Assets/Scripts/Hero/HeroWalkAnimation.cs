namespace Game.Hero
{
	using UnityEngine;

	[RequireComponent(typeof(Animator))]
	public sealed class HeroWalkAnimation : MonoBehaviour
	{
		Animator _animator;
		
		void Start()
		{
			_animator = GetComponent<Animator>();
		}
	}
}