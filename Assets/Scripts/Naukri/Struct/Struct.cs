using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Naukri.Struct
{
	[System.Serializable]
	public class Edge
	{
		public Vector2 origin, Gap;

		public Edge()
		{

		}

		public Edge(Vector2 origin, Vector2 size)
		{
			this.origin = origin;
			this.Gap = size / 2;
		}
		public Vector2 Left
		{
			get
			{
				return new Vector2(origin.x - Gap.x, origin.y);
			}
		}
		public Vector2 Right
		{
			get
			{
				return new Vector2(origin.x + Gap.x, origin.y);
			}
		}
		public Vector2 Top
		{
			get
			{
				return new Vector2(origin.x, origin.y + Gap.y);
			}
		}

		public Vector2 Bottom
		{
			get
			{
				return new Vector2(origin.x, origin.y - Gap.y);
			}
		}

		public Vector2 LT
		{
			get
			{
				return new Vector2(origin.x - Gap.x, origin.y - Gap.y);
			}
		}
		public Vector2 RT
		{
			get
			{
				return new Vector2(origin.x + Gap.x, origin.y - Gap.y);
			}
		}
		public Vector2 LB
		{
			get
			{
				return new Vector2(origin.x - Gap.x, origin.y + Gap.y);
			}
		}
		public Vector2 RB
		{
			get
			{
				return new Vector2(origin.x + Gap.x, origin.y + Gap.y);
			}
		}
	}
}
