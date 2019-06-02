using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 軍隊詳細資料
/// </summary>
[System.Serializable]
public class TroopDetails : DetailsBase
{
	/// <summary>
	/// 移動速度
	/// </summary>
	public AgentSpeed Speed;

	/// <summary>
	/// 攻擊力
	/// </summary>
	public int Damage;

	/// <summary>
	/// 攻擊範圍
	/// </summary>
	public float HitRange;

	/// <summary>
	/// 攻擊偏好
	/// </summary>
	[EnumFlags("Hit Favor")]
	public AgentType HitFavor;

	/// <summary>
	/// KB值
	/// </summary>
	public int KnockBack;

	/// <summary>
	/// 訓練時間
	/// </summary>
	public int TrainingTime;

	/// <summary>
	/// 金幣
	/// </summary>
	public int Gold;

	/// <summary>
	/// 建構子
	/// </summary>
	/// <param name="identify">目標ID</param>
	public TroopDetails(int identify)
	{
		DataReader reader = new DataTable("Troop").SelectRow(identify);
		//General
		Name = reader.Get<string>("Name");
		Type = (AgentType)reader.Get<int>("Type");
		Comment = reader.Get<string>("Comment");
		GrowthRate = reader.Get<float>("GrowthRate");
		Level = 1;
		MaxHitPoint = HitPoint = reader.Get<int>("HitPoint");
		//Troop
		Speed = (AgentSpeed)reader.Get<int>("Speed");
		Damage = reader.Get<int>("Damage");
		HitRange = reader.Get<float>("HitRange");
		HitFavor = (AgentType)reader.Get<int>("HitFavor");
		KnockBack = reader.Get<int>("KnockBack");
		TrainingTime = reader.Get<int>("TrainingTime");
		Gold = reader.Get<int>("Gold");
		//
		reader.SqliteReader.Close();
	}

	/// <summary>
	/// 升一級
	/// </summary>
	/// <returns></returns>
	public override bool Upgrade()
	{
		if (Level >= 10) return false;
		Level++;
		int newMaxHitPoint = (int)(MaxHitPoint * GrowthRate);
		HitPoint += newMaxHitPoint - MaxHitPoint;
		MaxHitPoint = newMaxHitPoint;
		//
		Damage = (int)(MaxHitPoint * GrowthRate);
		KnockBack = (int)(KnockBack * GrowthRate);
		Gold = (int)(Gold * GrowthRate);
		return true;
	}

	/// <summary>
	/// 升級至level級
	/// </summary>
	/// <param name="level">目標等級</param>
	/// <returns>升級是否成功</returns>
	public override bool SetLevel(int level)
	{
		if (level <= Level || Level >= 10) return false;
		float growthScale = Mathf.Pow(GrowthRate, level - Level);
		Level = level;
		int newMaxHitPoint = (int)(MaxHitPoint * growthScale);
		HitPoint += newMaxHitPoint - MaxHitPoint;
		MaxHitPoint = newMaxHitPoint;
		//
		Damage = (int)(Damage * growthScale);
		KnockBack = (int)(KnockBack * growthScale);
		Gold = (int)(Gold * growthScale);
		return true;
	}
}
