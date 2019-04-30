using UnityEngine;

/// <summary>
/// 受傷能力
/// </summary>
[DisallowMultipleComponent]
[AddComponentMenu("AgentAbility/Troop/AlertAbility")]
public class AlertAbility : AbilityBase
{
	/// <summary>
	/// 被擊退
	/// </summary>
	public bool KnockBack;

	/// <summary>
	/// 無敵倒數
	/// </summary>
	[SerializeField] private float _tmrInvincilbeTime;

	/// <summary>
	/// 建構子
	/// </summary>
	private AlertAbility()
	{
		Priority = AbilityPriority.Alert;
		AnimClip = AbilityAnimClip.Alert;
	}

	public override void EveryFrame()
	{

	}

	public override bool Triggers()
	{
		return KnockBack;
	}

	public override void Enter()
	{
		_agent.gameObject.layer = GameArgs.InvincilbeMask;
		_agent.Rigidbody.AddForce(new Vector2(_agent.Team == AgentTeam.Ally ? -200f : 200f, 200f));
	}

	public override void Stay()
	{
		if (_agent.IsGrounded)
		{
			KnockBack = false;
		}
	}

	public override void Exit()
	{
		gameObject.layer = (int)_agent.Team;
	}
}
