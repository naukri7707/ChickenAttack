using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[AddComponentMenu("AgentAbility/General/GoldProduceAbility")]
public class GoldProduceAbility : AbilityBase
{
	public Image GoldBar;

	public int BasisGoldProduce;

	private GoldProduceAbility()
	{
		Priority = AbilityPriority.GoldProduce;
		AnimClip = AbilityAnimClip.Idle;
	}

	private void Start()
	{

	}


	public override void EveryFrame()
	{
		GoldBar.fillAmount += 0.005f;
		if (GoldBar.fillAmount >= 1)
		{
			GameArgs.Gold += (int)(BasisGoldProduce * Mathf.Pow(_agent.GetDetails<DetailsBase>().GrowthRate, _agent.GetDetails<DetailsBase>().Level - 1));
			GoldBar.fillAmount = 0;
		}
	}

	public override bool Triggers()
	{
		return false;
	}

	public override void Enter()
	{

	}

	public override void Stay()
	{

	}

	public override void Exit()
	{

	}
}