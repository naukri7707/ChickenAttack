using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[AddComponentMenu("AgentAbility/Troop/DeadAbility")]
public class DeadAbility : AbilityBase
{
	private DeadAbility()
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
		_agent.Collider.enabled = false;
		_agent.Rigidbody.AddForce(new Vector2(_agent.Team == AgentTeam.Ally ? -200f : 200f, 400f));
	}

	public override void Stay()
	{
		_agent.SpriteRenderer.color -= new Color(0, 0, 0, 0.01f);
		if (transform.position.y < -15)
			Destroy(gameObject);
	}

	public override void Exit()
	{

	}
}
