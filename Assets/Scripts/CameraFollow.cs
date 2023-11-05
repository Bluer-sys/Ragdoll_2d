namespace Game
{
	using Game.Extensions;
	using UnityEngine;

	public sealed class CameraFollow : MonoBehaviour
	{
		[SerializeField] Transform	_target;
		[SerializeField] float		_speed;
		
		Transform _cameraTransform;


		void Start()
		{
			_cameraTransform = Camera.main.transform;
		}

		void LateUpdate()
		{
			Vector3 cameraPos	= _cameraTransform.position;
			Vector3 targetPos	= _target.position;
			
			if ( Vector2.Distance( cameraPos, targetPos ) < float.Epsilon )
				return;

			Vector3 newPos		= Vector3.Lerp( cameraPos, targetPos, _speed * Time.deltaTime ).WithZ( cameraPos.z );
			
			_cameraTransform.position = newPos;
		}
	}
}