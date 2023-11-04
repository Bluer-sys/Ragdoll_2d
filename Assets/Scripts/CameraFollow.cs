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
			if ( Vector2.Distance( _cameraTransform.position, _target.position ) < float.Epsilon )
				return;

			Vector3 targetPos	= Vector3.Lerp( _cameraTransform.position, _target.position, _speed * Time.deltaTime ).WithZ( -10 );
			
			_cameraTransform.position = targetPos;
		}
	}
}