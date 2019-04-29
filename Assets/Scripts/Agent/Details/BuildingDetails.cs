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
}
