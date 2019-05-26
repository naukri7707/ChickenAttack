using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 軍隊代理核心
/// </summary>
[RequireComponent(typeof(Animator))]
public class TroopCore : CoreBase
{
	/// <summary>
	/// 詳細資料
	/// </summary>
	[SerializeField] private TroopDetails _details;

	/// <summary>
	/// 取得詳細資料
	/// </summary>
	/// <returns></returns>
	protected override DetailsBase GetDetailsBase()
	{
		return _details;
	}

	/// <summary>
	/// 初始化
	/// </summary>
	protected override void Awake()
	{
		_details = new TroopDetails(Identify);
		base.Awake();
	}
}


