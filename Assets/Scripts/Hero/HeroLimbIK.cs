namespace Game.Hero
{
	using RootMotion.FinalIK;
	using UnityEngine;

	[RequireComponent(typeof(CCDIK))]
	public sealed class HeroLimbIK : MonoBehaviour
	{
		[SerializeField] CCDIK		_limb;

		void Start()
		{
			_limb.enabled = false;
		}

		public void SetEnabled(bool state)	=> _limb.enabled = state;
	}
}