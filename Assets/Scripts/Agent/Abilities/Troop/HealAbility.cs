using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[AddComponentMenu("AgentAbility/General/NoneAbility")]
public class HealAbility : AbilityBase
{
	/// <summary>
	/// 攻擊型態
	/// </summary>
	public AttackType HealType;

	/// <summary>
	/// 鎖定目標
	/// </summary>
	public CoreBase LockedAgent;

	/// <summary>
	/// 產生的物件
	/// </summary>
	public GameObject InstantiateObject;

	/// <summary>
	/// 判定設線起點
	/// </summary>
	private Vector2 _rayOrigin => transform.position - new Vector3(0, _agent.Collider.bounds.size.y / 2 - 0.5f);

	private HealAbility()
	{
		Priority = AbilityPriority.Heal;
		AnimClip = AbilityAnimClip.Attack;
	}

	public override void EveryFrame()
	{
		Debug.DrawRay(_rayOrigin, _agent.Direction * _agent.GetDetails<TroopDetails>().HitRange, Color.green);
	}

	public override bool Triggers()
	{
		RaycastHit2D[] hits = Physics2D.RaycastAll(_rayOrigin, _agent.Direction, _agent.GetDetails<TroopDetails>().HitRange, 1 << (int)_agent.Team);
		foreach (var hit in hits)
		{
			if (hit.transform.gameObject == gameObject) continue;
			var agent = hit.transform.transform.GetComponent<CoreBase>();
			if (agent.GetDetails<DetailsBase>().Type == AgentType.Building)
				continue;
			if (LockedAgent == null)
				LockedAgent = agent;
			else if (agent.GetDetails<DetailsBase>().HitPoint < agent.GetDetails<DetailsBase>().MaxHitPoint)
				LockedAgent = agent;
			return true;
		}
		return false;
	}

	public override void Enter()
	{
		_agent.Rigidbody.constraints |= RigidbodyConstraints2D.FreezePositionX;
	}

	public override void Stay()
	{

	}

	public override void Exit()
	{
		_agent.Rigidbody.constraints &= RigidbodyConstraints2D.FreezeRotation;
	}

	/// <summary>
	/// 普通攻擊
	/// </summary>
	public void NormalHeal()
	{
		var la = LockedAgent.GetDetails<DetailsBase>();
		la.HitPoint += _agent.GetDetails<TroopDetails>().Damage;
		if (la.HitPoint > la.MaxHitPoint)
			la.HitPoint = la.MaxHitPoint;
	}

	/// <summary>
	/// 遠程攻擊
	/// </summary>
	public void RemoteHeal()
	{
		GameObject tmp = Instantiate(InstantiateObject);
		tmp.transform.position = transform.position;
		tmp.GetComponent<EffectBase>().Initialization(LockedAgent, _agent.GetDetails<TroopDetails>().Damage, _agent.Team);
	}
}