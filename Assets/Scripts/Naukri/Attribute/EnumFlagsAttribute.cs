using UnityEngine;
using System.Collections;

public class EnumFlagsAttribute : PropertyAttribute
{
	/// <summary>
	/// 名稱
	/// </summary>
	public string text;

	// 命名
	public EnumFlagsAttribute(string label)
	{
		text = label;
	}

	// 不命名(空白)
	public EnumFlagsAttribute()
	{
		
	}

}