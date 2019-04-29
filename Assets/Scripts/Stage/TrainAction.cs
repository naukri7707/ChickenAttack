using System.Collections;
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
	public int Idnetify;

	/// <summary>
	/// 數量
	/// </summary>
	public int Amount;

	public TrainAction(int identify = 10001, int amount = 1)
	{
		Type = ActionType.Train;
		Idnetify = identify;
		Amount = amount;
	}

	public async Task DoActionAsync(CoreBase trainBy)
	{
		for (int i = 0; i < Amount; i++)
		{
			CoreBase g = Prefabs.Instantiate(Idnetify).GetComponent<CoreBase>();
			g.transform.SetOnHorizon(trainBy.transform.position.x);

			g.transform.parent = trainBy.transform.parent;
			g.SetTeam(trainBy.Team);
			g.GetDetails<DetailsBase>().DeBuff.AddFlag(AgentDeBuff.Freeze);
			g.GetComponent<SpriteRenderer>().material = trainBy.GetComponent<SpriteRenderer>().material;
			await Awaiters.Seconds(0.3f);
		}
	}

	public override Task DoActionAsync()
	{
		throw new System.NotImplementedException();
	}
}
