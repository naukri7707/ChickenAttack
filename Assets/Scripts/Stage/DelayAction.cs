using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class DelayAction : ActionBase
{
	/// <summary>
	/// 延遲 (秒)
	/// </summary>
	public float DelayTime;

	public DelayAction()
	{
		Type = ActionType.Delay;
	}

	public override async Task DoActionAsync()
	{
		await Awaiters.Seconds(DelayTime);
	}

}
