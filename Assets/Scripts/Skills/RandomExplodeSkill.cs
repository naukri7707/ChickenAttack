using Naukri.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class RandomExplodeSkill : SkillBase
{
	[SerializeField] private int count;
	public int Count { get => count; set => count = value; }

	[SerializeField] private int dmage;
	public int Dmage { get => dmage; set => dmage = value; }

	public override async void OnSkillAsync()
	{
		if (CurrentCoolDown > 0) return;
		CurrentCoolDown = CoolDown;
		for (int i = 0; i < Count; i++)
		{
			GameObject eff = Prefabs.Instantiate(30002, GameArgs.World.transform);
			eff.transform.SetOnHorizon();
			var det = eff.GetComponent<EffectBase>();
			det.Team = AgentTeam.Ally;
			det.TargetTeam = AgentTeam.Enemy;
			det.GetComponent<EffectBase>().Damage = Dmage;
			//
			CoreBase target = Naukri.Random.Objects((from t in GameArgs.World.GetComponentsInChildren<TroopCore>() where t.Team == AgentTeam.Enemy select t).ToArray());
			if (target == null)
				target = (from t in GameArgs.World.GetComponentsInChildren<BuildingCore>() where t.Team == AgentTeam.Enemy select t).ToArray()[0];
			eff.transform.SetOnHorizon(target.transform.position.x + Random.Range(-5f, 5f));
			eff.transform.Translate(new Vector3(0, -1.5f, 0));
			await Awaiters.Seconds(0.2f);
		}
	}
}
