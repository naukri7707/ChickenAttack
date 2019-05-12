using Naukri.ExtensionMethods;
using UnityEngine;

public class EffectBase : MonoBehaviour
{
	/// <summary>
	/// 衍生物件
	/// </summary>
	public GameObject InstantiateObject;

	/// <summary>
	/// 衍生物件起始位置修正
	/// </summary>
	public Vector2 InstantiateFixPosition;

	/// <summary>
	/// 目標物件
	/// </summary>
	public CoreBase Target { get; set; }

	/// <summary>
	/// 目標隊伍
	/// </summary>
	public AgentTeam TargetTeam;

	/// <summary>
	/// 目標x座標
	/// </summary>
	private float _targetPosX;

	/// <summary>
	/// 目標隊伍
	/// </summary>

	/// <summary>
	/// 目標x座標
	/// </summary>
	public float TargetPosX
	{
		get
		{
			if (Target != null)
			{
				_targetPosX = TargetTeam == AgentTeam.Ally ? Target.Collider.GetBoundsRect().xMax : Target.Collider.GetBoundsRect().xMin;
			}
			return _targetPosX;
		}
	}

	/// <summary>
	/// 傷害
	/// </summary>
	public int Damage { get; set; }

	public void DestroyThis()
	{
		Destroy(gameObject);
	}

	public void Initialization(CoreBase target, int damage)
	{
		if (target.Team == AgentTeam.Ally)
		{
			transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		}
		Target = target;
		TargetTeam = target.Team;
		Damage = damage;
	}

	public void Instantiate()
	{
		if (InstantiateObject == null)
		{
			return;
		}

		GameObject tmp = Instantiate(InstantiateObject, transform.position + (Vector3)InstantiateFixPosition, new Quaternion());
		tmp.GetComponent<EffectBase>().Initialization(Target, Damage);
	}

	public void Attack()
	{
		foreach (BoxCollider2D b in GetComponent<BoxCollider2D>().OverlapAll())
		{
			if (b.tag == GameArgs.Building || b.tag == GameArgs.Troop)
			{
				CoreBase agent = b.GetComponent<CoreBase>();
				if (agent.Team == TargetTeam)
				{
					agent.GetDetails<DetailsBase>().HitPoint -= Damage;
					if (agent.GetDetails<DetailsBase>().Type == AgentType.Troop && Damage >= agent.GetDetails<TroopDetails>().KnockBack)
					{
						agent.GetComponent<AlertAbility>().KnockBack = true;
					}
				}
			}
		}
	}

	public bool AttackOnce()
	{
		foreach (BoxCollider2D b in GetComponent<BoxCollider2D>().OverlapAll())
		{
			if (b.tag == GameArgs.Building || b.tag == GameArgs.Troop)
			{
				CoreBase agent = b.GetComponent<CoreBase>();
				Debug.Log(agent.Team + "," + TargetTeam);
				if (agent.Team == TargetTeam)
				{
					agent.GetDetails<DetailsBase>().HitPoint -= Damage;
					if (agent.GetDetails<DetailsBase>().Type == AgentType.Troop && Damage >= agent.GetDetails<TroopDetails>().KnockBack)
					{
						agent.GetComponent<AlertAbility>().KnockBack = true;
					}
					return true;
				}
			}
		}
		return false;
	}

#if false //UNITY_EDITOR
	public void OnDrawGizmos()
	{
		BoxCollider2D collider = GetComponent<BoxCollider2D>();
		Naukri.Tools.NGizmos.DrawBox(collider.transform.position + (Vector3)collider.offset, collider.bounds.size, new Vector2());
	}
#endif
}
