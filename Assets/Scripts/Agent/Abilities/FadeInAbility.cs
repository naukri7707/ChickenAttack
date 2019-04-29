using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
[AddComponentMenu("AgentAbility/General/FadeInAbility")]
public class FadeInAbility : AbilityBase
{
	private bool isFading = true;

	private FadeInAbility()
	{
		Priority = AbilityPriority.FadeIn;
		AnimClip = AbilityAnimClip.Idle;
	}

	public void Start()
	{
		_agent.SpriteRenderer.color = new Color(1, 1, 1, 0.2f);
	}

	public override void EveryFrame()
	{

	}

	public override bool Triggers()
	{
		return isFading;
	}

	public override void Enter()
	{

	}

	public override void Stay()
	{
		_agent.SpriteRenderer.color += new Color(0, 0, 0, 0.02f);
		if (_agent.SpriteRenderer.color.a > 0.95f) isFading = false;
	}

	public override void Exit()
	{
		_agent.SpriteRenderer.color = new Color(1, 1, 1, 1);
		_agent.AbilityManger.Abilities.Remove(this);
		Destroy(this);
	}
}
