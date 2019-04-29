using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naukri.ExtensionMethods;

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

	/// <summary>
	/// 目前關卡
	/// </summary>
	public static int CurrentStage;

	/// <summary>
	/// 世界物件
	/// </summary>
	public static GameObject World;

	/// <summary>
	/// 背景物件
	/// </summary>
	public static GameObject BackGround;

	/// <summary>
	/// 地平線
	/// </summary>
	public static float Horizon;

    /// <summary>
    /// 載入中的視窗
    /// </summary>
    public static int LoadingScene;

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
