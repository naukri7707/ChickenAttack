using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 建築代理核心
/// </summary>
public class BuildingCore : CoreBase
{
	/// <summary>
	/// 詳細資料
	/// </summary>
	[SerializeField] private BuildingDetails _details;

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
		_details = new BuildingDetails(Identify);
		base.Awake();
	}

	private void OnMouseUpAsButton()
	{
		if (Team == AgentTeam.Ally && GameArgs.FocusPermit && BuildBtnEvent.BuildingGameObject == null)
		{
			GameArgs.FocusBuilding = this;
			GameArgs.BuildingList.SetActive(true);
		}
	}
}
