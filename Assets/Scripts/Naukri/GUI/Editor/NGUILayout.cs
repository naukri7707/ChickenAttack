using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Naukri.GUILayout
{
	public class NGUILayout
	{
		public static string TagField(string lable, string value, params GUILayoutOption[] options)
		{
			UnityEngine.GUILayout.Label(lable);
			return EditorGUILayout.TagField(value, options);
		}

		public static string TextField(string lable, string value, params GUILayoutOption[] options)
		{
			UnityEngine.GUILayout.Label(lable);
			return EditorGUILayout.TextField(value, options);
		}

		public static void ReadOnlyField(string lable, string value, params GUILayoutOption[] options)
		{
			EditorGUILayout.BeginHorizontal();
			UnityEngine.GUILayout.Label(lable);
			EditorGUI.BeginDisabledGroup(true);
			EditorGUILayout.TextField(value, options);
			EditorGUI.EndDisabledGroup();
			EditorGUILayout.EndHorizontal();
		}

		public static int IntField(string lable, int value, params GUILayoutOption[] options)
		{
			UnityEngine.GUILayout.Label(lable);
			return EditorGUILayout.IntField(value, options);
		}

		public static float FloatField(string lable, float value, params GUILayoutOption[] options)
		{
			UnityEngine.GUILayout.Label(lable);
			return EditorGUILayout.FloatField(value, options);
		}

		public static double DoubleField(string lable, double value, params GUILayoutOption[] options)
		{
			UnityEngine.GUILayout.Label(lable);
			return EditorGUILayout.DoubleField(value, options);
		}

		public static System.Enum EnumPopup(string lable, System.Enum selected, params GUILayoutOption[] options)
		{
			UnityEngine.GUILayout.Label(lable);
			return EditorGUILayout.EnumPopup(selected, options);
		}

		public static System.Enum EnumFlagsPopup(string lable, System.Enum enumValue, params GUILayoutOption[] options)
		{
			UnityEngine.GUILayout.Label(lable);
			return EditorGUILayout.EnumFlagsField(enumValue, options);
		}


		public static Vector2 Vector2Field(string lable, Vector2 value, params GUILayoutOption[] options)
		{
			UnityEngine.GUILayout.Label(lable);
			return EditorGUILayout.Vector2Field("", value, options);
		}

		public static Vector3 Vector3Field(string lable, Vector3 value, params GUILayoutOption[] options)
		{
			UnityEngine.GUILayout.Label(lable);
			return EditorGUILayout.Vector3Field("", value, options);
		}

		public static Vector4 Vector4Field(string lable, Vector4 value, params GUILayoutOption[] options)
		{
			UnityEngine.GUILayout.Label(lable);
			return EditorGUILayout.Vector4Field("", value, options);
		}

		public static Vector2Int Vector2IntField(string lable, Vector2Int value, params GUILayoutOption[] options)
		{
			UnityEngine.GUILayout.Label(lable);
			return EditorGUILayout.Vector2IntField("", value, options);
		}

		public static Vector3Int Vector3IntField(string lable, Vector3Int value, params GUILayoutOption[] options)
		{
			UnityEngine.GUILayout.Label(lable);
			return EditorGUILayout.Vector3IntField("", value, options);
		}

		public static Object ObjectField<T>(string lable, T @object, bool allowSceneObject = true, params GUILayoutOption[] options) where T : Object
		{
			UnityEngine.GUILayout.Label(lable);
			return (EditorGUILayout.ObjectField(@object, @object.GetType(), allowSceneObject, options));
		}

		public static GameObject GameObjectField<T>(string lable, T @object, bool allowSceneObject = true, params GUILayoutOption[] options) where T : Object
		{
			UnityEngine.GUILayout.Label(lable);
			return (EditorGUILayout.ObjectField(@object, @object.GetType(), allowSceneObject, options)) as GameObject;
		}

		/// <summary>
		/// 用Reflection顯示何繼承自EditorWindow, MonoBehaviour, etc的參數propertyName
		/// </summary>
		/// <param name="propertyName">目標參數名</param>
		public static void ShowProperty(UnityEngine.Object target, string propertyName)
		{
			// "target" can be any class derrived from ScriptableObject 
			// (could be EditorWindow, MonoBehaviour, etc)
			SerializedObject so = new SerializedObject(target);
			SerializedProperty stringsProperty = so.FindProperty(propertyName);

			EditorGUILayout.PropertyField(stringsProperty, true); // True means show children
			so.ApplyModifiedProperties(); // Remember to apply modified properties
		}
	}
}
