using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;

/// <summary>
/// 資料查詢結果
/// </summary>
public class DataReader
{
	/// <summary>
	/// Sqlite原生DataReader
	/// </summary>
	public SqliteDataReader SqliteReader { get; private set; }

	/// <summary>
	/// 建構子
	/// </summary>
	/// <param name="reader"></param>
	public DataReader(SqliteDataReader reader)
	{
		SqliteReader = reader;
	}

	/// <summary>
	/// 將 DataReader 隱式轉換成 SqliteDataReader
	/// </summary>
	/// <param name="reader">DataReader</param>
	public static implicit operator SqliteDataReader(DataReader reader)
	{
		return reader.SqliteReader;
	}

	/// <summary>
	/// 將 SqliteDataReader 隱式轉換成 DataReader
	/// </summary>
	/// <param name="reader">SqliteDataReader</param>
	public static implicit operator DataReader(SqliteDataReader reader)
	{
		return new DataReader(reader);
	}

	/// <summary>
	/// 查詢目標欄位
	/// </summary>
	/// <value>欄位索引</value>
	public object this[int index]
	{
		get
		{
			return SqliteReader[index];
		}
	}

	/// <summary>
	/// 查詢目標欄位
	/// </summary>
	/// <value>欄位名稱</value>
	public object this[string name]
	{
		get
		{
			return SqliteReader[name];
		}
	}

	/// <summary>
	/// 取得轉型後的資料
	/// </summary>
	/// <param name="index">欄位索引</param>
	/// <typeparam name="T">目標型態</typeparam>
	/// <returns>轉型後的資料</returns>
	public T Get<T>(int index) where T : IConvertible
	{
		return (T)Convert.ChangeType(SqliteReader[index].ToString(), typeof(T));
	}

	/// <summary>
	/// 取得轉型後的資料
	/// </summary>
	/// <param name="name">欄位名稱</param>
	/// <typeparam name="T">目標型態</typeparam>
	/// <returns>轉型後的資料</returns>
	public T Get<T>(string name) where T : IConvertible
	{
		return (T)Convert.ChangeType(SqliteReader[name].ToString(), typeof(T));
	}

	/// <summary>
	/// 讀取下一行
	/// </summary>
	/// <returns>是否還有資料</returns>
	public bool Read()
	{
		return SqliteReader.Read();
	}

	/// <summary>
	/// 判斷DataReader是否有行
	/// </summary>
	/// <value>是否有列</value>
	public bool HasRows
	{
		get
		{
			return SqliteReader.HasRows;
		}
	}

	/// <summary>
	/// 共有幾列
	/// </summary>
	/// <value>列數</value>
	public int FieldCount
	{
		get
		{
			return SqliteReader.FieldCount;
		}
	}

	/// <summary>
	/// 取得所有資料
	/// </summary>
	/// <returns></returns>
	public object[] GetValues()
	{
		object[] res = new object[FieldCount];
		SqliteReader.GetValues(res);
		return res;
	}
	
	/// <summary>
	/// 取得所有欄位名稱
	/// </summary>
	/// <returns></returns>
	public string[] GetNames()
	{
		string[] res = new string[FieldCount];
		for (int i = 0; i < res.Length; i++)
			res[i] = SqliteReader.GetName(i);
		return res;
	}
}
