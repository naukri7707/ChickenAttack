using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
/*********************
 * 注意!!引數傳遞時
 * Class 為 CallBy Adress
 * Struct 為 CallBy Reference
 * 這意味著當 this 引數為 struct 時，你只能間接得更改他的值
 * ******************/
namespace Naukri.ExtensionMethods
{
	public static class Extension
	{
		public static T ConvertTo<T>(this object src) where T : IConvertible
		{
			return (T)Convert.ChangeType(src, typeof(T));
		}

		public static T As<T>(this object src)
		{
			return (T)src;
		}


		public static T DeepCopy<T>(this T src) where T : class
		{
			using (var ms = new MemoryStream())
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(ms, src);
				ms.Position = 0;
				return (T)formatter.Deserialize(ms);
			}
		}

		public static void Reset<T, U>(this List<T> src, int index, U value) where U : T
		{
			src.RemoveAt(index);
			src.Insert(index, value);
		}


		public static void Swap<T>(this List<T> src, int lhs, int rhs) where T : class
		{
			var tmp = src[rhs].DeepCopy();
			src.Reset(rhs, src[lhs].DeepCopy());
			src.Reset(lhs, tmp);
		}


		public static bool IsGrounded(this Transform t)
		{
			return Physics2D.Raycast(t.position, new Vector2(0, -1), t.GetComponent<Collider2D>().bounds.size.y / 2 + 0.01f, 1 << 9);
		}
		public static bool IsNearGround(this Transform t, Vector2 size)
		{
			return Physics2D.Raycast(t.position, new Vector2(0, -1), size.y / 2 + 2, 1 << 9);
		}

		public static Rect GetBoundsRect(this Collider2D c)
		{
			Rect rect = new Rect();
			Transform t = c.transform;
			//
			rect.center = t.position + new Vector3(c.offset.x * t.localScale.x, c.offset.y * t.localScale.y, 0);
			rect.xMin = rect.center.x - c.bounds.size.x;
			rect.xMax = rect.center.x + c.bounds.size.x;
			rect.yMin = rect.center.y - c.bounds.size.y;
			rect.yMax = rect.center.y + c.bounds.size.y;
			return rect;
		}

		public static void SetOnHorizon(this Transform t)
		{
			Collider2D col = t.GetComponent<Collider2D>();
			t.position = new Vector3(t.position.x, GameArgs.Horizon + col.bounds.size.y / 2, t.position.z);
		}

		public static void SetOnHorizon(this Transform t, float newX)
		{
			Collider2D col = t.GetComponent<Collider2D>();
			t.position = new Vector3(newX, GameArgs.Horizon + col.bounds.size.y / 2, t.position.z);
		}

		public static T GetComponent<T>(this UnityEngine.Object obj)
		{
			GameObject tmp = UnityEngine.Object.Instantiate(obj as GameObject);
			T res = tmp.GetComponent<T>();
			UnityEngine.Object.Destroy(tmp);
			return res;
		}

		public static Collider2D[] OverlapAll(this BoxCollider2D collider)
		{
			return Physics2D.OverlapBoxAll(collider.transform.position + (Vector3)collider.offset, collider.bounds.size, 0);
		}

		public static Vector2 BoundsOffset(this Collider2D collider)
		{
			return new Vector2(collider.offset.x * collider.transform.localScale.x, collider.offset.y * collider.transform.localScale.y);
		}
	}
}





