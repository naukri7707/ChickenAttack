using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[AddComponentMenu("AgentAbility/General/IdleAbility")]
public class IdleAbility : AbilityBase
{
    private IdleAbility()
    {
		Priority = AbilityPriority.Idle;
		AnimClip = AbilityAnimClip.Idle;
    }

    public override void EveryFrame()
    {

    }

    public override bool Triggers()
    {
        return true;
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