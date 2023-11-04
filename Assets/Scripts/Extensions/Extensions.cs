namespace Game.Extensions
{
	using UnityEngine;

	public static class Extensions
	{
		public static Vector3 WithZ(this Vector3 v, float z) => new Vector3( v.x, v.y, z );
	}
}