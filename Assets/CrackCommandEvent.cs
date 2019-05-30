using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using Naukri.ExtensionMethods;
using System.Threading.Tasks;

public class CrackCommandEvent : MonoBehaviour
{
	public GameObject filter;
	public Text text;
	// Start is called before the first frame update

	private void Awake()
	{
	}
	void OnEnable()
	{
		Time.timeScale = 0;

		filter.GetComponent<Image>().material = GameArgs.World.GetComponent<World>().MaterialBlurGass;
		GetComponent<InputField>().Select();
		GetComponent<InputField>().ActivateInputField();
	}

	public async void Execute()
	{
		var cmd = text.text.ToLower();
		Debug.Log(cmd);
		Time.timeScale = 1;
		filter.GetComponent<Image>().material = GameArgs.World.GetComponent<World>().MaterialDefault;
		switch (cmd)
		{
			case "gold":
				GameArgs.Gold += 1000;
				break;
			case "ace":
				foreach (var t in GameArgs.World.GetComponentsInChildren<TroopCore>())
				{
					if (t.Type == AgentType.Troop)
						t.GetDetails<TroopDetails>().HitPoint = 0;
				}
				break;
			case "how do you turn this on":
				{
					GameObject ins = Prefabs.Instantiate(10001, GameArgs.World.transform);
					ins.transform.SetOnHorizon(GameObject.Find("PumpkinFarm").transform.position.x);
					ins.transform.localScale = new Vector3(3, 3, 4);
					var det = ins.GetComponent<CoreBase>().GetDetails<TroopDetails>();
					det.Damage = det.HitPoint = det.KnockBack = int.MaxValue;
					det.Speed = AgentSpeed.VeryFast;
					break;
				}
			case "rush b":
				for (int i = 0; i < 50; i++)
				{
					GameObject ins = Prefabs.Instantiate(10001, GameArgs.World.transform);
					ins.transform.position = new Vector3(Random.Range(40, 50), Random.Range(-1, 20), 0);
					ins.GetComponent<CoreBase>().SetTeam(AgentTeam.Ally);
				}
				break;
			case "mercenary":
				foreach (var b in GameArgs.World.GetComponentsInChildren<CoreBase>())
				{
					if (b.Team == AgentTeam.Ally && b.Type == AgentType.Building)
					{
						for (int i = 0; i < 5; i++)
						{
							GameObject ins = Prefabs.Instantiate(10001, GameArgs.World.transform);
							ins.GetComponent<CoreBase>().SetTeam(AgentTeam.Ally);
							ins.transform.SetOnHorizon(b.transform.position.x + Random.Range(-5, 6));
						}
					}
				}
				for (int i = 0; i < 10; i++)
				{
					GameObject inst = Prefabs.Instantiate(10001, GameArgs.World.transform);
					inst.transform.position = new Vector3(Random.Range(40, 50), Random.Range(-1, 20), 0);
					inst.GetComponent<CoreBase>().SetTeam(AgentTeam.Ally);
				}
				break;
			case "exodia":
			case "!ex":
				{
					await Exodia();
					break;
				}
			case "nightmare":
			case "!nm":
				{
					await NightMare();
					break;
				}
		}
		if (cmd.Contains("+"))
		{
			int n;
			int.TryParse(Regex.Replace(cmd, "[^0-9]", ""), out n);
			GameArgs.Gold += n;
		}
		//指定生成
		if (cmd.Contains(">"))
		{
			int n;
			int.TryParse(Regex.Replace(cmd, "[^0-9]", ""), out n);
			GameObject ins = Prefabs.Instantiate(n, GameArgs.World.transform);
			ins.transform.SetOnHorizon(GameObject.Find("PumpkinFarm").transform.position.x);
			Debug.Log("Produce " + n);
		}
		//亂鬥
		if (cmd.Contains("melee") || cmd.Contains("!m"))
		{
			int n = 0;
			int.TryParse(Regex.Replace(cmd, "[^0-9]", ""), out n);
			if (n == 0) n = 100;
			for (int i = 0; i < n; i++)
			{
				GameObject ins = Prefabs.Instantiate(Random.Range(10001, 10009), GameArgs.World.transform);
				ins.transform.position = new Vector3(Random.Range(-40, 40), 0, 0);
				ins.transform.SetOnHorizon();
				ins.GetComponent<CoreBase>().SetTeam(Random.Range(0, 2) == 0 ? AgentTeam.Ally : AgentTeam.Enemy);
			}
		}
		//雞如雨下
		else if (cmd.Contains("chickenrain") || cmd.Contains("!cr"))
		{
			int n = 0;
			int.TryParse(Regex.Replace(cmd, "[^0-9]", ""), out n);
			if (n == 0) n = 100;
			for (int i = 0; i < n; i++)
			{
				GameObject ins = Prefabs.Instantiate(10001, GameArgs.World.transform);
				ins.transform.position = new Vector3(Random.Range(-40, 40), Random.Range(-1, 30), 0);
				ins.GetComponent<CoreBase>().SetTeam(Random.Range(0, 2) == 0 ? AgentTeam.Ally : AgentTeam.Enemy);
			}
		}

		if (cmd.Contains("ageis") || cmd.Contains("steroids"))
		{
			Debug.Log(12);
			int n = 0;
			int.TryParse(Regex.Replace(cmd, "[^0-9]", ""), out n);
			if (n == 0) n = 2;
			Time.timeScale = n;
		}

	}

	public async Task Exodia()
	{
		Material mt = GameArgs.World.GetComponent<World>().MateriaGrayScale;
		for (; ; )
		{
			GameObject eff = Prefabs.Instantiate(30002, GameArgs.World.transform);
			eff.transform.SetOnHorizon();
			var det = eff.GetComponent<EffectBase>();
			det.Team = Random.Range(0, 2) == 0 ? AgentTeam.Ally : AgentTeam.Enemy;
			det.TargetTeam = det.Team == AgentTeam.Ally ? AgentTeam.Enemy : AgentTeam.Ally;
			det.GetComponent<EffectBase>().Damage = 100;
			if (eff.GetComponent<EffectBase>().Team == AgentTeam.Enemy)
			{
				eff.GetComponent<SpriteRenderer>().material = mt;
			}
			eff.transform.SetOnHorizon(Random.Range(-40, 40));
			eff.transform.Translate(new Vector3(0, -3, 0));
			await Awaiters.Seconds(0.2f);
		}
	}
	public async Task NightMare()
	{
		float posX = GameObject.Find("EvilCastle").transform.position.x;
		for (; ; )
		{
			GameObject ins = Prefabs.Instantiate(Random.Range(10001, 10009), GameArgs.World.transform);
			ins.transform.SetOnHorizon(posX);
			ins.GetComponent<CoreBase>().SetTeam(AgentTeam.Enemy);
			await Awaiters.Seconds(0.5f);
		}
	}
}
