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
	/// <param name="Identify">ID</param>
	/// <returns>實例化物件</returns>
	public static GameObject Instantiate(int Identify)
    {
        if (Identify < 20000)
        {
            return Object.Instantiate(Troop[Identify]) as GameObject;
        }
        else
        {
            return Object.Instantiate(Building[Identify]) as GameObject;
        }
    }

	/// <summary>
	/// 軍隊預製表
	/// </summary>
	public readonly static Dictionary<int, Object> Troop = new Dictionary<int, Object>
    {
        {10001, Resources.Load("Troop/CurlChicken")},
		{10002, Resources.Load("Troop/PotionChicken")},
		{10003, Resources.Load("Troop/SwimChicken")},
	};

	/// <summary>
	/// 建築預製表
	/// </summary>
	public readonly static Dictionary<int, Object> Building = new Dictionary<int, Object>
    {
        {20001, Resources.Load("Building/PumpkinFarm")},
		{20002, Resources.Load("Building/TrainingTent")},
		{20003, Resources.Load("Building/TrainingHole")},
	};
}
