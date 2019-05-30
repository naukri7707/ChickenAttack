using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCastleDeadAbility : DeadAbility
{
	public EvilCastleDeadAbility()
	{
		Priority = AbilityPriority.Dead;
		AnimClip = AbilityAnimClip.Dead;
	}

	public override void EveryFrame()
	{

	}

	public override bool Triggers()
	{
		return (_agent.Details.HitPoint <= 0);
	}

	public override void Enter()
	{
		if (StageManager.MaxStage == GameArgs.CurrentStage)
			StageManager.MaxStage++;
	}

	public override void Stay()
	{
		_agent.SpriteRenderer.color -= new Color(0, 0, 0, 0.01f);
		if (_agent.SpriteRenderer.color.a <= 0.1f)
			Destroy(gameObject);
	}

	public override void Exit()
	{

	}
}
