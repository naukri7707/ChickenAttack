using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 預製物件
/// </summary>
public static class Prefabs
{
	/// <summary>
	/// 實例化
	/// </summary>
	/// <param name="identify">ID</param>
	/// <returns>實例化物件</returns>
	public static GameObject Instantiate(int identify)
	{
		if (identify < 20000)
		{
			return Object.Instantiate(Troop[identify]) as GameObject;
		}
		else if (identify < 30000)
		{
			return Object.Instantiate(Building[identify]) as GameObject;
		}
		else
		{
			return Object.Instantiate(Effect[identify]) as GameObject;
		}
	}
	public static GameObject Instantiate(int identify, Transform parent)
	{
		var tmp = Instantiate(identify);
		tmp.transform.parent = parent;
		return tmp;
	}
	/// <summary>
	/// 軍隊預製表
	/// </summary>
	public readonly static Dictionary<int, Object> Troop = new Dictionary<int, Object>
	{
		{10001, Resources.Load("Troop/CurlChicken")},
		{10002, Resources.Load("Troop/PotionChicken")},
		{10003, Resources.Load("Troop/SwimChicken")},
		{10004, Resources.Load("Troop/MageChicken")},
		{10005, Resources.Load("Troop/HealChicken")},
		{10006, Resources.Load("Troop/ArtisanChicken")},
		{10007, Resources.Load("Building/ChickenTower")},
		{10008, Resources.Load("Troop/SuperChicken")},

	};

	/// <summary>
	/// 建築預製表
	/// </summary>
	public readonly static Dictionary<int, Object> Building = new Dictionary<int, Object>
	{
		{20001, Resources.Load("Building/PumpkinFarm")},
		{20002, Resources.Load("Building/TrainingTent")},
		{20003, Resources.Load("Building/TrainingHole")},
		{20004, Resources.Load("Building/EvilCastle")},
		{20005, Resources.Load("Building/TrainingHouse")},
	};

	/// <summary>
	/// 效果預製表
	/// </summary>
	public readonly static Dictionary<int, Object> Effect = new Dictionary<int, Object>
	{
		{30001, Resources.Load("Effect/LevelUp")},
		{30002, Resources.Load("Effect/PotionExplosion")},
	};
}
