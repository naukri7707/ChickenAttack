using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 建築詳細資料
/// </summary>
[System.Serializable]
public class BuildingDetails : DetailsBase
{
	/// <summary>
	/// 升級時間
	/// </summary>
	public int UpgradeTime;

	/// <summary>
	/// 升級消耗
	/// </summary>
	public int UpgradeCost;

	/// <summary>
	/// 建構子
	/// </summary>
	/// <param name="identify"></param>
	public BuildingDetails(int identify)
	{
		DataReader reader = new DataTable("Building").SelectRow(identify);
		//General
		Name = reader.Get<string>("Name");
		Type = (AgentType)reader.Get<int>("Type");
		Comment = reader.Get<string>("Comment");
		GrowthRate = reader.Get<float>("GrowthRate");
		Level = 1;
		MaxHitPoint = HitPoint = reader.Get<int>("HitPoint");
		//Building
		UpgradeTime = reader.Get<int>("UpgradeTime");
		UpgradeCost = reader.Get<int>("UpgradeCost");
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
		UpgradeCost = (int)(UpgradeCost * GrowthRate);
		return true;
	}

	/// <summary>
	/// 升級至level級
	/// </summary>
	/// <param name="level">目標等級</param>
	/// <returns></returns>
	public override bool SetLevel(int level)
	{
		if (level <= Level || Level >= 10) return false;
		float growthScale = Mathf.Pow(GrowthRate, level - Level);
		Level = level;
		int newMaxHitPoint = (int)(MaxHitPoint * growthScale);
		HitPoint += newMaxHitPoint - MaxHitPoint;
		MaxHitPoint = newMaxHitPoint;
		//
		UpgradeCost = (int)(UpgradeCost * growthScale);
		return true;
	}
}
