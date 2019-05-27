using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[AddComponentMenu("AgentAbility/General/ShieldAbility")]
public class ShieldAbility : AbilityBase
{
	/// <summary>
	/// 攻擊型態
	/// </summary>
	public AttackType AttackType;

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

	private ShieldAbility()
	{
		Priority = AbilityPriority.None;
		AnimClip = AbilityAnimClip.Attack;
	}

	public override void EveryFrame()
	{
		Debug.DrawRay(_rayOrigin, _agent.Direction * _agent.GetDetails<TroopDetails>().HitRange, Color.green);
	}

	public override bool Triggers()
	{
		RaycastHit2D hit = Physics2D.Raycast(_rayOrigin, _agent.Direction, _agent.GetDetails<TroopDetails>().HitRange, _agent.EnemyLayerMask);
		if (hit)
		{
			LockedAgent = hit.collider.GetComponent<CoreBase>();
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
	/// 產生護盾
	/// </summary>
	public void MakeShield()
	{
		
	}
}