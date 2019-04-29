using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;

/// <summary>
/// 資料表
/// </summary>
public class DataTable
{
	/// <summary>
	/// 資料庫位置 (從StreamingAssetsPath 開始)
	/// </summary>
	private readonly string _connPath = "Data/Details.db";

	/// <summary>
	/// 資料表名稱
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// ID欄位名稱
	/// </summary>
	private readonly string _identifyField;

	/// <summary>
	/// 資料庫連線
	/// </summary>
	private SqliteConnection _conn;

	/// <summary>
	/// 資料庫指令
	/// </summary>
	private SqliteCommand _cmd;

	/// <summary>
	/// 資料表
	/// </summary>
	private SqliteDataReader _reader;

	/// <summary>
	/// 資料表行數
	/// </summary>
	public int Count => ExecuteQuery("SELECT COUNT(*) FROM " + Name).GetInt32(0);

	/// <summary>
	/// 建構資料庫連結
	/// </summary>
	/// <param name="tableName">資料表名稱</param>
	public DataTable(string tableName, string identifyField = "Identify")
	{
		Name = tableName;
		_identifyField = identifyField;
		try
		{
#if UNITY_ANDROID
			_connPath = "URL=file:Application.persistentDataPath/" + _connPath;
#elif UNITY_IOS
			_connPath = "data source=Application.persistentDataPath/" + _connPath;
#else
			_connPath = "data source=" + Application.streamingAssetsPath + "/"  + _connPath;
#endif
			_conn = new SqliteConnection(_connPath);
			_cmd = new SqliteCommand(_conn);
			_conn.Open();
		}
		catch (Exception e)
		{
			Debug.Log("連結失敗 : " + e.Message);
		}
	}

	/// <summary>
	/// 解構資料庫連結
	/// </summary>
	~DataTable()
	{
		_conn.Close();
	}

	/// <summary>
	/// 執行非查詢指令
	/// </summary>
	/// <param name="sqlQuery">SQL指令</param>
	/// <returns></returns>
	public int ExecuteNonQuery(string sqlQuery)
	{
		Debug.Log("(ExecuteNonQuery) " + sqlQuery);
		using (SqliteConnection conn = new SqliteConnection(_connPath))
		{
			using (SqliteCommand cmd = new SqliteCommand(sqlQuery, conn))
			{
				conn.Open();
				int res = cmd.ExecuteNonQuery();
				return res;
			}
		}
	}

	/// <summary>
	/// 執行查詢指令
	/// </summary>
	/// <param name="sqlQuery">SQL指令</param>
	/// <returns></returns>
	public SqliteDataReader ExecuteQuery(string sqlQuery)
	{
		_cmd.CommandText = sqlQuery;
		return _cmd.ExecuteReader();
	}

	#region -- Insert --
	/// <summary>
	/// 插入 依順序寫入資料
	/// </summary>
	/// <param name="fieldValues">要寫入的資料</param>
	/// <returns></returns>
	public int Insert(object[] fieldValues)
	{
		string[] formatValues = ObjectFormat(fieldValues);
		string query = "INSERT INTO " + Name + " VALUES (" + formatValues[0];
		for (int i = 1; i < formatValues.Length; i++)
		{
			query += "," + formatValues[i];
		}
		query += ")";
		return ExecuteNonQuery(query);
	}

	/// <summary>
	/// 插入 將資料寫入至對應欄位
	/// </summary>
	/// <param name="fieldNames">對應的欄位</param>
	/// <param name="fieldValues">要寫入的資料</param>
	/// <returns></returns>
	public int Insert(string[] fieldNames, object[] fieldValues)
	{
		if (fieldNames.Length != fieldValues.Length)
		{
			throw new SqliteException("fieldNames.Length != fieldValues.Length");
		}
		string[] formatValues = ObjectFormat(fieldValues);
		//SetQuery
		string query = "INSERT INTO " + Name + "(" + fieldNames[0];
		for (int i = 1; i < fieldNames.Length; ++i)
			query += ", " + fieldNames[i];
		query += ") VALUES (" + formatValues[0];
		for (int i = 1; i < formatValues.Length; ++i)
			query += ", " + formatValues[i];
		query += ")";

		return ExecuteNonQuery(query);
	}

	/// <summary>
	/// 插入 將資料寫入至對應欄位
	/// </summary>
	/// <param name="dataPairs">要寫入的資料</param>
	/// <returns></returns>
	public int Insert(DataPairs dataPairs)
	{
		return Insert(dataPairs.Names.ToArray(), dataPairs.Values.ToArray());
	}
	#endregion

	#region -- Update --
	/// <summary>
	/// 更新 將資料符寫入至符合判斷式的行對應欄位
	/// </summary>
	/// <param name="fieldNames">對應的欄位</param>
	/// <param name="fieldValues">要寫入的資料</param>
	/// <param name="judgement">判斷式</param>
	/// <returns></returns>
	public int Update(string[] fieldNames, object[] fieldValues, string judgement)
	{
		if (fieldNames.Length != fieldValues.Length)
		{
			throw new SqliteException("fieldNames.Length != fieldValues.Length");
		}
		string[] formatValues = ObjectFormat(fieldValues);
		//SetQuery
		string query = "UPDATE " + Name + " SET " + fieldNames[0] + "=" + formatValues[0];
		for (int i = 1; i < fieldNames.Length; ++i)
		{
			query += "," + fieldNames[i] + " = " + formatValues[i];
		}
		query += " WHERE " + judgement;

		return ExecuteNonQuery(query);
	}

	/// <summary>
	/// 更新 將資料符寫入至符合判斷式的行對應欄位
	/// </summary>
	/// <param name="dataPairs">要寫入的資料</param>
	/// <param name="judgement">判斷式</param>
	/// <returns></returns>
	public int Update(DataPairs dataPairs, string judgement)
	{
		return Update(dataPairs.Names.ToArray(), dataPairs.Values.ToArray(), judgement);
	}
	#endregion

	#region -- Delete --
	/// <summary>
	/// 刪除 將符合判斷式的行刪除
	/// </summary>
	/// <param name="judgement">判斷式</param>
	/// <returns></returns>
	public int Delete(string judgement)
	{
		return ExecuteNonQuery("DELETE FROM " + Name + " WHERE " + judgement);
	}
	#endregion

	#region -- Select --
	/// <summary>
	/// 查詢 指定欄位
	/// </summary>
	/// <param name="fieldName">欄位名稱</param>
	/// <returns></returns>
	public DataReader Select(string fieldName)
	{
		return ExecuteQuery("SELECT " + fieldName + " FROM " + Name);
	}

	/// <summary>
	/// 查詢 指定欄位
	/// </summary>
	/// <param name="fieldName">欄位名稱</param>
	/// <returns></returns>
	public DataReader Select(string[] fieldName)
	{
		string query = "SELECT " + fieldName[0];
		for (int i = 0; i < fieldName.Length; i++)
		{
			query += "," + fieldName[i];
		}
		query += " FROM " + Name;
		return ExecuteQuery(query);
	}

	/// <summary>
	/// 查詢 所有欄位
	/// </summary>
	/// <returns></returns>
	public DataReader SelectAll()
	{
		return ExecuteQuery("SELECT * FROM " + Name);
	}

	/// <summary>
	/// 查詢 所有符合判斷式的欄位
	/// </summary>
	/// <param name="judgement">判斷式</param>
	/// <returns></returns>
	public DataReader SelectAll(string judgement)
	{
		return ExecuteQuery("SELECT * FROM " + Name + " WHERE " + judgement);
	}
	#endregion

	/// <summary>
	/// 更新 目標行
	/// </summary>
	/// <param name="identify">目標ID</param>
	/// <param name="fieldNames">對應的欄位</param>
	/// <param name="fieldValues">要寫入的資料</param>
	/// <returns></returns>
	public int UpdateRow(int identify, string[] fieldNames, object[] fieldValues)
	{
		return Update(fieldNames, fieldValues, _identifyField + "=" + identify);
	}

	/// <summary>
	/// 更新 目標行
	/// </summary>
	/// <param name="identify">目標ID</param>
	/// <param name="dataPairs">要寫入的資料</param>
	/// <returns></returns>
	public int UpdateRow(int identify, DataPairs dataPairs)
	{
		return Update(dataPairs.Names.ToArray(), dataPairs.Values.ToArray(), _identifyField + "=" + identify);
	}

	/// <summary>
	/// 刪除 目標行
	/// </summary>
	/// <param name="identify">目標ID</param>
	/// <returns></returns>
	public int DeleteRow(int identify)
	{
		return Delete(_identifyField + "=" + identify);
	}

	/// <summary>
	/// 查詢 目標行
	/// </summary>
	/// <param name="identify">目標ID</param>
	/// <returns></returns>
	public DataReader SelectRow(int identify)
	{
		return SelectAll(_identifyField + "=" + identify);
	}

	/// <summary>
	/// 查詢 所有ID
	/// </summary>
	/// <returns></returns>
	public int[] IDList()
	{
		List<int> res = new List<int>();
		_reader = Select(_identifyField);
		while (_reader.Read())
		{
			res.Add(_reader.GetInt32(0));
		}
		return res.ToArray();
	}

	/// <summary>
	/// 取得所有資料表名稱
	/// </summary>
	/// <returns>查詢結果</returns>
	public string[] GetAllTableName()
	{
		List<string> res = new List<string>();
		_reader = ExecuteQuery("SELECT Name FROM sqlite_master WHERE TYPE = 'table'");
		while (_reader.Read())
		{
			if (_reader[0].ToString().Contains("sqlite_")) continue;
			res.Add(_reader[0].ToString());
		}
		return res.ToArray();
	}

	/// <summary>
	/// 將物件格式化並轉換成字串
	/// </summary>
	/// <param name="objects">目標物件</param>
	/// <returns></returns>
	private static string ObjectFormat(object objects)
	{
		if (objects is string)
			return "'" + objects.ToString() + "'";
		else if (objects is Enum)
			return ((int)objects).ToString();
		else
			return objects.ToString();
	}

	/// <summary>
	/// 將物件格式化並轉換成字串
	/// </summary>
	/// <param name="objects">目標物件</param>
	/// <returns></returns>
	private static string[] ObjectFormat(object[] objects)
	{
		string[] res = new string[objects.Length];
		for (int i = 0; i < objects.Length; i++)
		{
			res[i] = ObjectFormat(objects[i]);
		}
		return res;
	}
}
