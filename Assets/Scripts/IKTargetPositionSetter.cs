namespace Game
{
	using UnityEngine;

	public sealed class IKTargetPositionSetter : MonoBehaviour
	{
		[SerializeField] AimPoint _aimPoint;

		void Update()
		{
			transform.position = _aimPoint.GetPosition();
		}
	}
}