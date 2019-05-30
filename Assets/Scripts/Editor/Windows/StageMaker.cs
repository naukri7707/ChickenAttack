using Naukri.GUILayout;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Naukri.ExtensionMethods;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// 關卡編輯器
/// </summary>
public class StageMaker : EditorWindow
{
	private int _targetStage;

	/// <summary>
	/// 動作表
	/// </summary>
	[SerializeField] List<ActionBase> _actions;

	/// <summary>
	/// 滑條位置
	/// </summary>
	private Vector2 _scrollPos;

	/// <summary>
	/// 創建窗口
	/// </summary>
	[MenuItem("Tools/StageMaker")]
	private static void AddWindow()
	{
		GetWindow(typeof(StageMaker));
	}

	/// <summary>
	/// 每幀更新
	/// </summary>
	private void OnGUI()
	{
		if (_actions == null || _actions.Count == 0)
		{
			if (GUILayout.Button("NewList"))
			{
				_actions = new List<ActionBase>();
				_actions.Add(new TrainAction());
			}
			GUILayout.FlexibleSpace();
		}
		else
		{
			DrawTable();
		}
		//
		_targetStage = EditorGUILayout.IntField("TargetStage", _targetStage);
		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button("Save"))
		{
			Naukri.IO.SetStage(_actions, _targetStage);
			Debug.Log("Save Complete");
		}
		if (GUILayout.Button("Load"))
		{
			Naukri.IO.GetStage(out _actions, _targetStage);
			Debug.Log("Load Successful");
		}
		if (GUILayout.Button("Clear"))
		{
			_actions = null;
		}
		EditorGUILayout.EndHorizontal();
	}

	/// <summary>
	/// 繪製動作表
	/// </summary>
	public void DrawTable()
	{
		_scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
		int deep = 0;
		for (int i = 0; i < _actions.Count; i++)
		{
			ActionBase action = _actions[i];
			EditorGUILayout.BeginHorizontal();
			//
			for (int j = deep; j > 0; j--)
			{
				GUILayout.Space(10);
				if (j == 1)
				{
					if (action.Type != ActionType.EndLoop)
						GUILayout.Label("├");
					else
						GUILayout.Label("└");
				}
				else
				{
					GUILayout.Label("│");
				}
			}
			EditorGUI.BeginChangeCheck();
			action.Type = (ActionType)EditorGUILayout.EnumPopup(action.Type, GUILayout.Width(80));
			if (EditorGUI.EndChangeCheck())
			{
				switch (action.Type)
				{
					case ActionType.Train:
						_actions.Reset(i, new TrainAction());
						break;
					case ActionType.Delay:
						_actions.Reset(i, new DelayAction());
						break;
					case ActionType.Loop:
						_actions.Reset(i, new LoopAction());
						break;
					case ActionType.EndLoop:
						_actions.Reset(i, new EndLoopAction());
						break;
					case ActionType.LevelUp:
						_actions.Reset(i, new LevelUpAction());
						break;
					case ActionType.Warning:
						_actions.Reset(i, new WarningAction());
						break;
				}
				return;
			}
			switch (action.Type)
			{
				case ActionType.Train:
					EditorGUI.BeginChangeCheck();
					Object newObject = (NGUILayout.GameObjectField("", Prefabs.Troop[action.As<TrainAction>().Idnetify], true, GUILayout.Width(120)));
					if (EditorGUI.EndChangeCheck())
					{
						int newID = (newObject as GameObject).GetComponent<CoreBase>().Identify;
						if (newID >= 10000 && newID < 20000)
						{
							action.As<TrainAction>().Idnetify = newID;
						}
					}
					action.As<TrainAction>().Amount = NGUILayout.IntField("Amount", action.As<TrainAction>().Amount, GUILayout.Width(80));
					break;
				case ActionType.Delay:
					action.As<DelayAction>().DelayTime = EditorGUILayout.FloatField(action.As<DelayAction>().DelayTime, GUILayout.Width(80));
					GUILayout.Label("s");
					break;
				case ActionType.Loop:
					action.As<LoopAction>().LoopTimes = EditorGUILayout.IntField(action.As<LoopAction>().LoopTimes, GUILayout.Width(80));
					GUILayout.Label("times");
					deep++;
					break;
				case ActionType.EndLoop:
					deep--;
					break;
				case ActionType.LevelUp:
					//
					break;
				case ActionType.Warning:
					action.As<WarningAction>().WarningType = (WarningType)NGUILayout.EnumPopup("", action.As<WarningAction>().WarningType, GUILayout.Width(80));
					if (action.As<WarningAction>().WarningType == WarningType.Custom)
					{
						action.As<WarningAction>().CustomText = NGUILayout.TextField("Text", action.As<WarningAction>().CustomText);
					}
					action.As<WarningAction>().TextColor = EditorGUILayout.ColorField("", action.As<WarningAction>().TextColor, GUILayout.Width(80));
					break;
			}
			DrawButtonFamily(i);
			GUILayout.FlexibleSpace();
			EditorGUILayout.EndHorizontal();
		}
		GUILayout.FlexibleSpace();
		EditorGUILayout.EndScrollView();
	}

	/// <summary>
	/// 繪製按鈕群組
	/// </summary>
	/// <param name="index">索引</param>
	/// <returns></returns>
	private bool DrawButtonFamily(int index)
	{
		EditorGUI.BeginDisabledGroup(index == 0);
		if (GUILayout.Button("▲", EditorStyles.miniButtonLeft, GUILayout.Width(20f)))
		{
			_actions.Swap(index, index - 1);
			return true;
		}
		EditorGUI.EndDisabledGroup();
		EditorGUI.BeginDisabledGroup(index == _actions.Count - 1);
		if (GUILayout.Button("▼", EditorStyles.miniButtonMid, GUILayout.Width(20f)))
		{
			_actions.Swap(index, index + 1);
			return true;
		}
		EditorGUI.EndDisabledGroup();
		if (GUILayout.Button("+", EditorStyles.miniButtonMid, GUILayout.Width(20f)))
		{
			_actions.Insert(index + 1, new TrainAction());
			return true;
		}
		if (GUILayout.Button("✘", EditorStyles.miniButtonRight, GUILayout.Width(20f)))
		{
			EditorApplication.Beep();

			if (EditorUtility.DisplayDialog("Warning!", "Are you sure?", "Yes", "No"))
			{
				_actions.Remove(_actions[index]);
				return true;
			}
		}
		return false;
	}
}