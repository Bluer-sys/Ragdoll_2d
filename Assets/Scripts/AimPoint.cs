namespace Game
{
	using Game.Input;
	using UnityEngine;

	public sealed class AimPoint : MonoBehaviour
	{
		[SerializeField] float _sensitivity;
		
		Vector2		_min;
		Vector2		_max;

		Camera		_camera;
		Transform	_transform;
		
		void Start()
		{
			_camera		= Camera.main;
			_transform	= GetComponent<Transform>();

			_min	= _camera.ViewportToScreenPoint( Vector3.zero );
			_max	= _camera.ViewportToScreenPoint( Vector3.one );
		}

		void Update()
		{
			Vector3 current		= _transform.position;
			Vector3 addon		= PlayerInput.Instance.AimDirection * _sensitivity * Time.deltaTime;
			Vector3 target		= current + addon;

			_transform.position = new Vector3( 
				Mathf.Clamp( target.x, _min.x, _max.x ),
				Mathf.Clamp( target.y, _min.y, _max.y ), 
				0 
			);
		}
	}
}