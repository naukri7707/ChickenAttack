﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naukri.ExtensionMethods;
using UnityEngine.UI;

/// <summary>
/// 通用靜態參數
/// </summary>
public static class GameArgs
{
	/// <summary>
	/// 所有物件的圖層
	/// </summary>
	public const int ObjectLayer = 1 << 9 | 1 << 10 | 1 << 11;

	public const int InvincilbeMask = 8;

	/// <summary>
	/// 軍隊
	/// </summary>
	public const string Troop = "Troop";

	/// <summary>
	/// 建築
	/// </summary>
	public const string Building = "Building";

	public const string Background = "BackGround";

	public const string Shield = "Shield";

	/// <summary>
	/// 金幣
	/// </summary>
	public static int Gold { get; set; }

	/// <summary>
	/// 警告文字
	/// </summary>
	public static Text WarningText { get; set; }

	/// <summary>
	/// 建築是否可被聚焦
	/// </summary>
	public static bool FocusPermit { get; set; }

	/// <summary>
	/// 聚焦建築
	/// </summary>
	public static CoreBase FocusBuilding { get; set; }

	/// <summary>
	/// 建築按鈕清單
	/// </summary>
	public static GameObject BuildingList { get; set; }

	/// <summary>
	/// 目前關卡
	/// </summary>
	public static int CurrentStage { get; set; }

	/// <summary>
	/// UI物件
	/// </summary>
	public static GameObject UI { get; set; }

	/// <summary>
	/// 世界物件
	/// </summary>
	public static GameObject World { get; set; }

	/// <summary>
	/// 南瓜農場
	/// </summary>
	public static BuildingCore PumpkinFarm { get; set; }

	/// <summary>
	/// 邪惡城堡
	/// </summary>
	public static BuildingCore EvilCastle { get; set; }

	/// <summary>
	/// 背景物件
	/// </summary>
	public static GameObject BackGround { get; set; }

	/// <summary>
	/// 地面碰撞器物件
	/// </summary>
	public static GameObject Ground { get; set; }

	/// <summary>
	/// 地平線
	/// </summary>
	public static float Horizon { get; set; }

	/// <summary>
	/// 載入中的視窗
	/// </summary>
	public static int LoadingScene { get; set; }

	/// <summary>
	/// 將物件設置在地平線上
	/// </summary>
	/// <param name="target">目標</param>
	public static void SetObjectOnHorizon(Transform target)
	{
		Collider2D col = target.GetComponent<Collider2D>();
		target.position = new Vector3(target.position.x, Horizon + col.bounds.size.y / 2, target.position.z);
	}

	/// <summary>
	/// 將物件設置在地平線上
	/// </summary>
	/// <param name="target">目標</param>
	/// <param name="newX">X</param>
	public static void SetObjectOnHorizon(Transform target, float newX)
	{
		Collider2D col = target.GetComponent<Collider2D>();
		target.position = new Vector3(newX, Horizon + col.bounds.size.y / 2, target.position.z);
	}
}
