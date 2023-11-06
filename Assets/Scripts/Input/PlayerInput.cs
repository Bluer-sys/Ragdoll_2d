namespace Game.Input
{
	using SimpleInputNamespace;
	using UnityEngine;
	using UnityEngine.Events;
	using UnityEngine.UI;

	public sealed class PlayerInput : MonoBehaviour
	{
		[SerializeField] ExtendedButton _leftButton;
		[SerializeField] ExtendedButton _rightButton;
		
		[SerializeField] Button _jumpButton;
		
		[SerializeField] Button _aimButton;
		[SerializeField] Button _grabButton;

		[SerializeField] Joystick _aimJoystick;

		static PlayerInput _instance;
		
#region Property

		public static PlayerInput Instance	=> _instance ??= FindObjectOfType<PlayerInput>();

		public float MoveAxis		{ get; private set; }
		public Vector2 AimDirection	{ get; private set; }

		public UnityEvent OnJump	{ get; } = new();
		public UnityEvent OnAim		{ get; } = new();
		public UnityEvent OnGrab	{ get; } = new();

#endregion

		void Awake()
		{
			DontDestroyOnLoad( Instance );
		}

		void OnEnable()
		{
			_leftButton.OnPointerDownEvent.AddListener( () => SetMoveAxis( -1 ) );			
			_rightButton.OnPointerDownEvent.AddListener( () => SetMoveAxis( 1 ) );		
			
			_leftButton.OnPointerUpEvent.AddListener( () => SetMoveAxis( 0 ) );			
			_rightButton.OnPointerUpEvent.AddListener( () => SetMoveAxis( 0 ) );			
			
			_jumpButton.onClick.AddListener( () => OnJump.Invoke() );
			
			_aimButton.onClick.AddListener( () => OnAim.Invoke() );
			_grabButton.onClick.AddListener( () => OnGrab.Invoke() );
		}

		void OnDisable()
		{
			_leftButton.OnPointerDownEvent.RemoveListener( () => SetMoveAxis( -1 ) );			
			_rightButton.OnPointerDownEvent.RemoveListener( () => SetMoveAxis( 1 ) );		
			
			_leftButton.OnPointerUpEvent.RemoveListener( () => SetMoveAxis( 0 ) );			
			_rightButton.OnPointerUpEvent.RemoveListener( () => SetMoveAxis( 0 ) );
			
			_jumpButton.onClick.RemoveListener( () => OnJump.Invoke() );
			
			_aimButton.onClick.RemoveListener( () => OnAim.Invoke() );
			_grabButton.onClick.RemoveListener( () => OnGrab.Invoke() );
		}

		void Update()
		{
			AimDirection = _aimJoystick.Value;
			
#if UNITY_EDITOR
			
			if ( Input.GetKeyDown( KeyCode.Space ) )
				OnJump.Invoke();
			
			if( Input.GetKey( KeyCode.A ) || Input.GetKey( KeyCode.D ) )
				MoveAxis = Input.GetAxis( "Horizontal" );

			if ( Input.GetKeyUp( KeyCode.A ) || Input.GetKeyUp( KeyCode.D ) )
				MoveAxis = 0;
#endif
		}

		
		void SetMoveAxis(float value)	=> MoveAxis = value;
	}
}