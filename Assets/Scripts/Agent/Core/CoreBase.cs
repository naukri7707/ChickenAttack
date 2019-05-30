using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 代理核心基底
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[DisallowMultipleComponent]
public abstract class CoreBase : MonoBehaviour
{
	/// <summary>
	/// 隊伍
	/// </summary>
	public AgentTeam Team;

	public AgentType Type
	{
		get => Details.Type;
	}

	/// <summary>
	/// 代理ID
	/// </summary>
	public int Identify;
	/// <summary>
	/// 敵人的圖層
	/// </summary>
	public LayerMask EnemyLayerMask => Team == AgentTeam.Ally ? 1 << (int)AgentTeam.Enemy : 1 << (int)AgentTeam.Ally;

	/// <summary>
	/// 當前能力
	/// </summary>
	public AbilityPriority CurrentAbility => AbilityManger.CurrentAbility.Priority;

	/// <summary>
	/// 方向
	/// </summary>
	public Vector2 Direction => new Vector2(Team == AgentTeam.Ally ? 1 : -1, 0);

	/// <summary>
	/// 剛體
	/// </summary>
	[HideInInspector] public Rigidbody2D Rigidbody;
	/// <summary>
	/// 碰撞器
	/// </summary>
	[HideInInspector] public BoxCollider2D Collider;

	/// <summary>
	/// 渲染器
	/// </summary>
	[HideInInspector] public SpriteRenderer SpriteRenderer;

	/// <summary>
	/// 能力管理員
	/// </summary>
	public AbilityManager AbilityManger;

	/// <summary>
	/// 詳細資料 (通用)
	/// </summary>
	public DetailsBase Details;

	protected abstract DetailsBase GetDetailsBase();

	/// <summary>
	/// 取得詳細資料
	/// </summary>
	/// <typeparam name="T">資料類別</typeparam>
	/// <returns>詳細資料</returns>
	public T GetDetails<T>() where T : DetailsBase => Details.As<T>();

	/// <summary>
	/// 是否在地上
	/// </summary>
	public bool IsGrounded => Physics2D.Raycast(transform.position, new Vector2(0, -1), (Collider.bounds.size.y / 2) + 0.01f, 1 << 9);

	/// <summary>
	/// 初始化
	/// </summary>
	protected virtual void Awake()
	{
		AbilityManger = new AbilityManager(GetComponents<AbilityBase>(), GetComponent<Animator>());
		Rigidbody = GetComponent<Rigidbody2D>();
		Collider = GetComponent<BoxCollider2D>();
		SpriteRenderer = GetComponent<SpriteRenderer>();
		//
		SetTeam(Team);
		//
		Details = GetDetailsBase();
	}

	public void Start()
	{
		SpriteRenderer.material = Team == AgentTeam.Ally ? GameArgs.World.GetComponent<World>().MaterialDefault : GameArgs.World.GetComponent<World>().MateriaGrayScale;
	}

	/// <summary>
	/// 固定式更新
	/// </summary>
	private void FixedUpdate()
	{
		AbilityManger.ProcessAbility();
		Debug.DrawLine(new Vector3(-100, GameArgs.Horizon), new Vector3(100, GameArgs.Horizon));
	}

	/// <summary>
	/// 設置隊伍
	/// </summary>
	/// <param name="team"></param>
	public void SetTeam(AgentTeam team)
	{
		Team = team;
		transform.localScale = new Vector3((Team == AgentTeam.Ally ? 1 : -1) * transform.localScale.x, transform.localScale.y, transform.localScale.z);
		gameObject.layer = (int)Team;
	}

}
