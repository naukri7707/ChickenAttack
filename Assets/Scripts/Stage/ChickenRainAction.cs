using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class ChickenRainAction : ActionBase
{
	/// <summary>
	/// 物件編號
	/// </summary>
	public int Identify;

	/// <summary>
	/// 數量
	/// </summary>
	public int Amount;

	public ChickenRainAction(int identify = 10001, int amount = 20)
	{
		Type = ActionType.ChickenRain;
		Identify = identify;
		Amount = amount;
	}

	public override async Task DoActionAsync()
	{
		for (int i = 0; i < Amount; i++)
		{
			GameObject ins = Prefabs.Instantiate(Identify, GameArgs.World.transform);
			CoreBase[] targets = (from a in GameArgs.World.GetComponentsInChildren<TroopCore>() where a.Team == AgentTeam.Ally && a.Type == AgentType.Troop select a).ToArray();
			if (targets.Length == 0)
				targets = (from a in GameArgs.World.GetComponentsInChildren<BuildingCore>() where a.Team == AgentTeam.Ally && a.Identify != 20001 select a).ToArray();
			if (targets.Length == 0)
				targets = (from a in GameArgs.World.GetComponentsInChildren<BuildingCore>() where a.Team == AgentTeam.Ally select a).ToArray();
			float posX = Naukri.Random.Objects(targets).transform.position.x + Random.Range(-5f, 0);
			if (posX < -35)
				posX = -35 + +Random.Range(5f, 0);
			ins.transform.position = new Vector3(posX, Random.Range(-1f, 10f), 0);
			ins.GetComponent<CoreBase>().SetTeam(AgentTeam.Enemy);
			await Awaiters.Seconds(0.1f);
		}
		await Awaiters.Seconds(2f);
	}
}
