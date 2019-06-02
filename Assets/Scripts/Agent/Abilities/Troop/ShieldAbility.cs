using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[AddComponentMenu("AgentAbility/General/ShieldAbility")]
public class ShieldAbility : AbilityBase
{
	public CoreBase Shield;

	/// <summary>
	/// 護盾冷卻
	/// </summary>
	public float ShieldCoolDown;

	/// <summary>
	/// 護盾剩餘時間
	/// </summary>
	public float ShieldTime { get; set; }

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
		Priority = AbilityPriority.Shield;
		AnimClip = AbilityAnimClip.Attack;
	}

	public override void EveryFrame()
	{
		//警界距離
		Debug.DrawRay(_rayOrigin, _agent.Direction * _agent.GetDetails<TroopDetails>().HitRange, Color.green);
		ShieldTime -= Time.deltaTime;
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
		if (ShieldTime <= 0)
		{
			if (Shield != null)
				Shield.GetDetails<TroopDetails>().HitPoint = 0;
			Shield = Instantiate(InstantiateObject).GetComponent<CoreBase>();
			Shield.Team = _agent.Team;
			Shield.gameObject.layer = 16;
			TroopDetails det = Shield.GetComponent<CoreBase>().GetDetails<TroopDetails>();
			det.Level = _agent.GetDetails<DetailsBase>().Level;
			float scale = Mathf.Pow(det.GrowthRate, det.Level - 1);
			det.MaxHitPoint = det.HitPoint = (int)(det.MaxHitPoint * scale);
			det.Damage = (int)(det.Damage * scale);
			det.KnockBack = (int)(det.KnockBack * scale);
			det.Gold = (int)(det.Gold * scale);
			Shield.transform.position = transform.position;
			ShieldTime = ShieldCoolDown;
		}
	}
	public void OnDestroy()
	{
		if (Shield != null)
			Shield.GetDetails<TroopDetails>().HitPoint = 0;
	}
}