namespace Game.Input
{
	using UnityEngine.Events;
	using UnityEngine.EventSystems;
	using UnityEngine.UI;

	public sealed class ExtendedButton : Button
	{
		public UnityEvent OnPointerUpEvent = new();
		public UnityEvent OnPointerDownEvent = new();
		
		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown( eventData );
			
			OnPointerDownEvent.Invoke();
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp( eventData );
			
			OnPointerUpEvent.Invoke();
		}
	}
}