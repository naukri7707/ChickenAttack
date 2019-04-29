using UnityEngine;

/// <summary>
/// 詳細資料基底
/// </summary>
public abstract class DetailsBase
{
	/// <summary>
	/// 名子
	/// </summary>
	public string Name;

	/// <summary>
	/// 種類
	/// </summary>
	public AgentType Type;

	/// <summary>
	/// 註解
	/// </summary>
	public string Comment;

	/// <summary>
	/// 等級
	/// </summary>
	public int Level;

	/// <summary>
	/// 成長比
	/// </summary>
	public float GrowthRate;

	/// <summary>
	/// 最大生命值
	/// </summary>
	public int MaxHitPoint;

	/// <summary>
	/// 生命值
	/// </summary>
	public int HitPoint;

	/// <summary>
	/// 異常狀態
	/// </summary>
	[EnumFlags("DeBuff")] public AgentDeBuff DeBuff;

	/// <summary>
	/// 視作子類別
	/// </summary>
	/// <typeparam name="T">目標類別</typeparam>
	/// <returns></returns>
	public T As<T>() where T : DetailsBase
	{
		return (T)this;
	}
}
