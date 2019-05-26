using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Naukri.GUILayout;

[CustomEditor(typeof(AttackAbility), true)]
public class AttackAbilityDarwer : Editor
{

	AttackAbility m_Target;

	private void OnEnable()
	{
		m_Target = (AttackAbility)target;
	}

	public override void OnInspectorGUI()
	{
		m_Target.AttackType = (AttackType)EditorGUILayout.EnumPopup("AttackType", m_Target.AttackType);
		NGUILayout.ShowProperty(target, "LockedAgent");
		if (m_Target.AttackType != AttackType.Normal)
		{
			EditorGUILayout.Space();
			NGUILayout.ShowProperty(target, "InstantiateObject");
		}
	}
}
