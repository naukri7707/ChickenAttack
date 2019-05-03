using UnityEngine;

[DisallowMultipleComponent]
[AddComponentMenu("AgentAbility/General/GoldProduceAbility")]
public class GoldProduceAbility : AbilityBase
{
	public int BasisGoldProduce;

	private GoldProduceAbility()
	{
		Priority = AbilityPriority.GoldProduce;
		AnimClip = AbilityAnimClip.Idle;
	}

	private void Start()
	{
		InvokeRepeating("GoldProduce", 0, 1f);
	}

	private void GoldProduce()
	{
		GameArgs.Gold += BasisGoldProduce * _agent.GetDetails<DetailsBase>().Level;
	}

	public override void EveryFrame()
	{

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