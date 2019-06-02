using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class LevelUpAction : ActionBase
{
	public LevelUpAction()
	{
		Type = ActionType.LevelUp;
	}

	public void DoAction(CoreBase trainBy)
	{
		if (trainBy.Details.Level < 10)
			trainBy.GetDetails<BuildingDetails>().Upgrade();
	}

	public override async Task DoActionAsync()
	{
		await Awaiters.Seconds(0);
	}

}
