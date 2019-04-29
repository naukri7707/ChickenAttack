using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 攻擊型態
/// </summary>
public enum AttackType
{
	Normal,
	Remote,
}

/// <summary>
/// 攻擊能力
/// </summary>
[DisallowMultipleComponent]
[AddComponentMenu("AgentAbility/Troop/AttackAbility")]
public class AttackAbility : AbilityBase
{
	/// <summary>
	/// 攻擊型態
	/// </summary>
	public AttackType AttackType;

	/// <summary>
	/// 調整位置
	/// </summary>
	public Vector3 FixPosition;

	/// <summary>
	/// 鎖定目標
	/// </summary>
	public CoreBase LockedAgent;
	
	/// <summary>
	/// 接觸目標點
	/// </summary>
	public Vector2 HitPoint;

	/// <summary>
	/// 產生的物件
	/// </summary>
	public GameObject InstantiateObject;

	/// <summary>
	/// 判定設線起點
	/// </summary>
	private Vector2 _rayOrigin => transform.position - new Vector3(0, _agent.Collider.bounds.size.y / 2 - 0.5f);

	/// <summary>
	/// 建構子
	/// </summary>
	private AttackAbility()
	{
		Priority = AbilityPriority.Attack;
		AnimClip = AbilityAnimClip.Attack;
	}

	public override void EveryFrame()
	{

	}

	public override bool Triggers()
	{
		Debug.DrawRay(_rayOrigin, _agent.Direction* _agent.GetDetails<TroopDetails>().HitRange);
		RaycastHit2D hit = Physics2D.Raycast(_rayOrigin, _agent.Direction, _agent.GetDetails<TroopDetails>().HitRange, _agent.EnemyLayerMask);
		if(hit)
		{
			LockedAgent = hit.collider.GetComponent<CoreBase>();
			HitPoint = hit.point;
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
	public void NormalAttack()
	{
		LockedAgent.GetDetails<DetailsBase>().HitPoint -= _agent.GetDetails<TroopDetails>().Damage;
		if (LockedAgent.GetDetails<DetailsBase>().Type == AgentType.Troop &&
			_agent.GetDetails<TroopDetails>().Damage >= LockedAgent.GetDetails<TroopDetails>().KnockBack)
			LockedAgent.GetComponent<AlertAbility>().KnockBack = true;
	}

	/// <summary>
	/// 遠程攻擊
	/// </summary>
	public void RemoteAttack()
	{
		GameObject tmp = Instantiate(InstantiateObject, transform.position + FixPosition, new Quaternion());
		GetComponent<ThrowingEffect>().Initialization(LockedAgent.Team, HitPoint, _agent.GetDetails<TroopDetails>().Damage);
	}
}
