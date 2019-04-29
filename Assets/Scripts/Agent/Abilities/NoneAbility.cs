using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[AddComponentMenu("AgentAbility/General/NoneAbility")]
public class NoneAbility : AbilityBase
{
	private NoneAbility()
	{
		Priority = AbilityPriority.None;
		AnimClip = AbilityAnimClip.Idle;
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