using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Naukri
{
    public static class NMath
    {
        public static Vector2 GetVector2(float Angle)
        {
            return Quaternion.Euler(0, 0, -Angle) * Vector2.up;
        }

        public static float GetAngle(Vector2 main, Vector2 compare)
        {
            if (main.x == compare.x && main.y >= compare.y) return 180;
            compare -= main;
            float angle = Vector2.Angle(Vector2.up, compare);
            return (compare.x < 0 ? -angle : angle);
        }

		public static float Gap(Vector2 lhs , Vector2 rhs)
		{
			return Mathf.Sqrt((lhs.x - rhs.x) * (lhs.x - rhs.x) + (lhs.y - rhs.y) * (lhs.y - rhs.y));
		}
    }
}
