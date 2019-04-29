using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 代理核心 編輯器繪製
/// </summary>
[CustomEditor(typeof(CoreBase), true)]
public class CoreBaseDrawer : Editor
{
	/// <summary>
	/// 代理核心
	/// </summary>
	CoreBase m_Target;

	/// <summary>
	/// 顯示優先度
	/// </summary>
	bool _showPriority = true;

	/// <summary>
	/// 初始化
	/// </summary>
	private void OnEnable()
	{
		m_Target = (CoreBase)target;
	}

	/// <summary>
	/// 當聚焦於Inspector時更新
	/// </summary>
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		if (EditorApplication.isPlaying)
		{
			EditorGUILayout.TextField("CurrentAbility", m_Target.CurrentAbility.ToString());

			if (_showPriority = EditorGUILayout.Foldout(_showPriority, "AbilitiesPriority"))
			{
				foreach (AbilityBase ability in m_Target.AbilityManger.Abilities)
					EditorGUILayout.TextField(((int)ability.Priority).ToString(), ability.Priority.ToString());
			}
		}
	}
}
