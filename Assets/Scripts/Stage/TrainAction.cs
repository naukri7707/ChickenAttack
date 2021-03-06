﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Naukri.ExtensionMethods;

[System.Serializable]
public class TrainAction : ActionBase
{
	/// <summary>
	/// 物件編號
	/// </summary>
	public int Identify;

	/// <summary>
	/// 數量
	/// </summary>
	public int Amount;

	public TrainAction(int identify = 10001, int amount = 1)
	{
		Type = ActionType.Train;
		Identify = identify;
		Amount = amount;
	}

	public async Task DoActionAsync(CoreBase trainBy)
	{
		for (int i = 0; i < Amount; i++)
		{
			CoreBase g = Prefabs.Instantiate(Identify).GetComponent<CoreBase>();
			g.transform.SetOnHorizon(trainBy.transform.position.x);
			//
			TroopDetails det = g.GetComponent<CoreBase>().GetDetails<TroopDetails>();
			det.DeBuff.AddFlag(AgentDeBuff.Freeze);
			det.SetLevel(trainBy.Details.Level);
			//
			g.transform.parent = trainBy.transform.parent;
			g.SetTeam(trainBy.Team);
			await Awaiters.Seconds(0.1f);
		}
	}

	public override Task DoActionAsync()
	{
		throw new System.NotImplementedException();
	}
}
