using UnityEngine;
using Naukri.Struct;

namespace Naukri.Tools
{
	public static class NGizmos
	{
		public static Color Color = Color.green;

		public static void DrawRay(Vector2 origin, Vector2 direction)
		{
			Gizmos.color = Color;
			Gizmos.DrawRay(origin, direction);
		}

		public static void DrawRay(Vector2 origin, Vector2 direction, float distance)
		{
			Gizmos.color = Color;
			Gizmos.DrawRay(origin, direction * distance);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="origin">原點</param>
		/// <param name="size">大小</param>
		/// <param name="direction">位移</param>
		public static void DrawBox(Vector2 origin, Vector2 size, Vector2 direction)
		{
			Gizmos.color = Color;
			//
			Edge start = new Edge(origin, size);
			Edge end = new Edge(origin + direction, size);
			//start
			Gizmos.DrawLine(start.LT, start.RT);
			Gizmos.DrawLine(start.RT, start.RB);
			Gizmos.DrawLine(start.RB, start.LB);
			Gizmos.DrawLine(start.LB, start.LT);
			//end
			Gizmos.DrawLine(end.LT, end.RT);
			Gizmos.DrawLine(end.RT, end.RB);
			Gizmos.DrawLine(end.RB, end.LB);
			Gizmos.DrawLine(end.LB, end.LT);
			//link
			Gizmos.DrawLine(start.LT, end.LT);
			Gizmos.DrawLine(start.RT, end.RT);
			Gizmos.DrawLine(start.RB, end.RB);
			Gizmos.DrawLine(start.LB, end.LB);
			//Arrow
			DrawArrow(start.origin, direction);
		}

		public static void DrawArrow(Vector3 origin, Vector3 direction, float arrowAngle = 25.0f)
		{
			float arrowLength = NMath.Gap(origin, origin + direction)/7;
			Gizmos.color = Color;
			Gizmos.DrawRay(origin, direction);
			Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 90, arrowAngle) * new Vector3(1, 0, 0);
			Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 90, -arrowAngle) * new Vector3(1, 0, 0);
			Gizmos.DrawRay(origin + direction, right * arrowLength);
			Gizmos.DrawRay(origin + direction, left * arrowLength);
		}
	}
}
