using Naukri.ExtensionMethods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class BossWaveAction : ActionBase
{
	[SerializeField] private int identify;

	/// <summary>
	/// 物件編號
	/// </summary>
	public int Identify { get => identify; set => identify = value; }

	[SerializeField] private int amount;

	/// <summary>
	/// 數量
	/// </summary>
	public int Amount { get => amount; set => amount = value; }

	public BossWaveAction(int identify = 10001, int amount = 1)
	{
		Type = ActionType.BossWave;
		Identify = identify;
		Amount = amount;
	}

	public async Task DoActionAsync(CoreBase trainBy)
	{
		for (int i = 0; i < Amount; i++)
		{
			CoreBase g = Prefabs.Instantiate(Identify).GetComponent<CoreBase>();
			g.transform.localScale = new Vector3(g.transform.localScale.x * 1.5f, g.transform.localScale.y * 1.5f, 1);
			g.transform.SetOnHorizon(trainBy.transform.position.x);
			//
			TroopDetails det = g.GetComponent<CoreBase>().GetDetails<TroopDetails>();
			det.DeBuff.AddFlag(AgentDeBuff.Freeze);
			det.SetLevel(trainBy.Details.Level);
			det.HitPoint *= 2;
			det.KnockBack *= 4;
			det.HitRange *= 1.5f;
			det.Damage = (int)(det.Damage * 1.5f);
			//
			g.transform.parent = trainBy.transform.parent;
			g.SetTeam(trainBy.Team);
			await Awaiters.Seconds(2f);
		}
	}

	public override Task DoActionAsync()
	{
		throw new System.NotImplementedException();
	}
}
