using Naukri.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MercenarySkill : SkillBase
{
	[SerializeField] private int count;

	public int Count { get => count; set => count = value; }

	public override void OnSkillAsync()
	{
		if (CurrentCoolDown > 0 || GameArgs.Gold < Cost) return;
		GameArgs.Gold -= Cost;
		CurrentCoolDown = CoolDown;
		int c = count + GameArgs.PumpkinFarm.Details.Level / count;
		foreach (var b in from b in GameArgs.World.GetComponentsInChildren<CoreBase>() where b.Team == AgentTeam.Ally && b.Type == AgentType.Building select b)
		{
			for (int i = 0; i < c; i++)
			{
				GameObject ins = Prefabs.Instantiate(10001, GameArgs.World.transform);
				ins.GetComponent<CoreBase>().SetTeam(AgentTeam.Ally);
				ins.transform.SetOnHorizon(b.transform.position.x + Random.Range(-5f, 6f));
			}
		}
	}
}
