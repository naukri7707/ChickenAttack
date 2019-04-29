using Naukri.Struct;
using UnityEngine;

namespace Naukri.Tools
{
	public static class NDebug
	{
		public static void DrawRay(Vector2 origin, Vector2 direction)
		{
			Debug.DrawRay(origin, direction);
		}

		public static void DrawBox(Vector2 origin, Vector2 size)
		{
			Edge node = new Edge(origin, size);
			//
			Debug.DrawLine(node.LT, node.RT);
			Debug.DrawLine(node.RT, node.RB);
			Debug.DrawLine(node.RB, node.LB);
			Debug.DrawLine(node.LB, node.LT);
		}
	}
}


