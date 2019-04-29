using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移動能力
/// </summary>
[DisallowMultipleComponent]
[AddComponentMenu("AgentAbility/Troop/MoveAbility")]
public class MoveAbility : AbilityBase
{
	/// <summary>
	/// 建構子
	/// </summary>
	private MoveAbility()
	{
		Priority = AbilityPriority.Move;
		AnimClip = AbilityAnimClip.Move;
	}

	public override void EveryFrame()
	{

	}

	public override bool Triggers()
	{
		return !_agent.Details.DeBuff.HasFlag(AgentDeBuff.Freeze);
	}

	public override void Enter()
	{

	}

	public override void Stay()
	{
		float v = (float)_agent.GetDetails<TroopDetails>().Speed / 5;
		if (_agent.Team == AgentTeam.Enemy) v = -v;
		_agent.Rigidbody.velocity = new Vector2(v, _agent.Rigidbody.velocity.y);
	}

	public override void Exit()
	{

	}
}
