using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 資料對
/// </summary>
public class DataPairs
{
	/// <summary>
	/// 名子
	/// </summary>
	public List<string> Names;

	/// <summary>
	/// 值
	/// </summary>
	public List<object> Values;

	/// <summary>
	/// 建構子
	/// </summary>
	public DataPairs()
	{
		Names = new List<string>();
		Values = new List<object>();
	}

	/// <summary>
	/// 數量
	/// </summary>
	int Count => Names.Count;

	/// <summary>
	/// 新增
	/// </summary>
	/// <param name="name">名稱</param>
	/// <param name="value">值</param>
	public void Add(string name, object value)
	{
		Names.Add(name);
		Values.Add(value);
	}

	/// <summary>
	/// 刪除
	/// </summary>
	/// <param name="index">索引</param>
	public void RemoveAt(int index)
	{
		Names.RemoveAt(index);
		Values.RemoveAt(index);
	}
}
