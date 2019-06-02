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

	/// <summary>
	/// 升一級
	/// </summary>
	/// <returns></returns>
	public virtual bool Upgrade()
	{
		if (Level >= 10) return false;
		Level++;
		int newMaxHitPoint = (int)(MaxHitPoint * GrowthRate);
		HitPoint += newMaxHitPoint - MaxHitPoint;
		MaxHitPoint = newMaxHitPoint;
		return true;
	}

	/// <summary>
	/// 升級至level級
	/// </summary>
	/// <param name="level">目標等級</param>
	/// <returns>升級是否成功</returns>
	public virtual bool SetLevel(int level)
	{
		if (level <= Level || Level >= 10) return false;
		float growthScale = Mathf.Pow(GrowthRate, level - Level);
		Level = level;
		int newMaxHitPoint = (int)(MaxHitPoint * growthScale);
		HitPoint += newMaxHitPoint - MaxHitPoint;
		MaxHitPoint = newMaxHitPoint;
		return true;
	}
}
