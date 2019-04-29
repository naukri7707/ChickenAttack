using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using Naukri.ExtensionMethods;
using Naukri.GUILayout;

/// <summary>
/// 資料型態
/// </summary>
public enum DataType
{
	Lock,
	String,
	Int,
	Float,
	AgentType,
	AgentTypeFlags,
	AgentSpeed,
}

/// <summary>
/// 資料庫查看工具
/// </summary>
public class DataViewer : EditorWindow
{
	/// <summary>
	/// 軍隊資料型態表
	/// </summary>
	private readonly DataType[] _troopDataType = new DataType[]
	{
		DataType.Lock ,
		DataType.String ,
		DataType.AgentType ,
		DataType.String ,
		DataType.Float,
		DataType.Int ,
		//
        DataType.AgentSpeed ,
		DataType.Int,
		DataType.Float,
		DataType.AgentTypeFlags,
		DataType.Int,
		DataType.Int,
	};

	/// <summary>
	/// 建築資料型態
	/// </summary>
	private readonly DataType[] _buildingDataType = new DataType[]
	{
		DataType.Lock ,
		DataType.String ,
		DataType.AgentType ,
		DataType.String ,
		DataType.Float,
		DataType.Int ,
		//
		DataType.Int,
		DataType.Int,
	};

	/// <summary>
	/// 滑條位置
	/// </summary>
	private Vector2 _scrollPos;

	/// <summary>
	/// 欄位名稱
	/// </summary>
	private string[] _tableFieldName;

	/// <summary>
	/// 資料表選單
	/// </summary>
	private string[] _tableList;

	/// <summary>
	/// 當前資料表
	/// </summary>
	private int _currentTableSelection;

	/// <summary>
	/// 當前資料表名稱
	/// </summary>
	private string _currentTable => _tableList[_currentTableSelection];

	/// <summary>
	/// 資料表主體
	/// </summary>
	private List<object[]> _dataTable;

	/// <summary>
	/// 創建窗口
	/// </summary>
	[MenuItem("Tools/DataViewer")]
	private static void AddWindow()
	{
		GetWindow(typeof(DataViewer));
	}

	/// <summary>
	/// 初始化
	/// </summary>
	private void OnEnable()
	{
		_tableList = new DataTable("").GetAllTableName();
		//
		DataReader reader = new DataTable(_currentTable).SelectAll();
		_dataTable = new List<object[]>();
		_tableFieldName = reader.GetNames();
		while (reader.Read())
		{
			_dataTable.Add(reader.GetValues());
		}
	}

	/// <summary>
	/// 每幀更新
	/// </summary>
	void OnGUI()
	{
		LoadTable();
		switch (_currentTable)
		{
			case "Troop":
				ShowTable(_troopDataType);
				break;
			case "Building":
				ShowTable(_buildingDataType);
				break;
		}
	}

	/// <summary>
	/// 讀取資料表
	/// </summary>
	private void LoadTable()
	{
		EditorGUILayout.BeginHorizontal();
		_currentTableSelection = EditorGUILayout.Popup(_currentTableSelection, _tableList);
		if (GUILayout.Button("Load"))
		{
			DataReader reader = new DataTable(_currentTable).SelectAll();
			_dataTable = new List<object[]>();
			_tableFieldName = reader.GetNames();
			while (reader.Read())
			{
				_dataTable.Add(reader.GetValues());
			}
		}
		EditorGUILayout.EndHorizontal();
	}

	/// <summary>
	/// 繪製資料表
	/// </summary>
	/// <param name="dataType">目標資料</param>
	private void ShowTable(DataType[] dataType)
	{
		_scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
		for (int i = 0; i < _dataTable.Count; i++)
		{
			EditorGUILayout.BeginHorizontal();
			for (int j = 0; j < _dataTable[i].Length; j++)
			{
				switch (dataType[j])
				{
					case DataType.Lock:
						NGUILayout.ReadOnlyField(_tableFieldName[j], _dataTable[i][j].ConvertTo<string>());
						break;
					case DataType.String:
						_dataTable[i][j] = NGUILayout.TextField(_tableFieldName[j], _dataTable[i][j].ConvertTo<string>());
						break;
					case DataType.Int:
						_dataTable[i][j] = NGUILayout.IntField(_tableFieldName[j], _dataTable[i][j].ConvertTo<int>());
						break;
					case DataType.Float:
						_dataTable[i][j] = NGUILayout.FloatField(_tableFieldName[j], _dataTable[i][j].ConvertTo<float>());
						break;
					case DataType.AgentType:
						_dataTable[i][j] = NGUILayout.EnumPopup(_tableFieldName[j], (AgentType)_dataTable[i][j].ConvertTo<int>());
						break;
					case DataType.AgentTypeFlags:
						_dataTable[i][j] = NGUILayout.EnumFlagsPopup(_tableFieldName[j], (AgentType)_dataTable[i][j].ConvertTo<int>());
						break;
					case DataType.AgentSpeed:
						_dataTable[i][j] = NGUILayout.EnumPopup(_tableFieldName[j], (AgentSpeed)_dataTable[i][j].ConvertTo<int>());
						break;
				}
			}
			if (GUILayout.Button("Save"))
			{
				new DataTable(_currentTable).UpdateRow(_dataTable[i][0].ConvertTo<int>(), _tableFieldName, _dataTable[i]);
			}

			if (GUILayout.Button("Del"))
			{
				new DataTable(_currentTable).DeleteRow(_dataTable[i][0].ConvertTo<int>());
				_dataTable.RemoveAt(i);
			}
			EditorGUILayout.EndHorizontal();
		}
		AddButton();
		EditorGUILayout.EndScrollView();

	}

	/// <summary>
	/// 新增按鈕
	/// </summary>
	private void AddButton()
	{
		if (GUILayout.Button("Add"))
		{
			_dataTable.Add((object[])_dataTable[_dataTable.Count - 1].Clone());
			_dataTable.LastOrDefault()[0] = _dataTable.LastOrDefault()[0].ConvertTo<int>() + 1;
			new DataTable(_currentTable).Insert(_tableFieldName, _dataTable.LastOrDefault());
		}
	}
}
