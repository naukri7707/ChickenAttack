using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 能力基底
/// </summary>
public abstract class AbilityBase : MonoBehaviour
{
	/// <summary>
	/// 優先度
	/// </summary>
	[System.NonSerialized] public AbilityPriority Priority;

	/// <summary>
	/// 對應動畫ID
	/// </summary>
	[System.NonSerialized] public AbilityAnimClip AnimClip;

	/// <summary>
	/// 能力持有者
	/// </summary>
	protected CoreBase _agent;

	/// <summary>
	/// 初始化
	/// </summary>
	protected virtual void Awake()
	{
		_agent = GetComponent<CoreBase>();
	}

	/// <summary>
	/// 每幀皆執行
	/// </summary>
	public abstract void EveryFrame();

	/// <summary>
	/// 能力觸發器
	/// </summary>
	/// <returns>是否觸發</returns>
	public abstract bool Triggers();

	/// <summary>
	/// 進入時
	/// </summary>
	public abstract void Enter();

	/// <summary>
	/// 停留時
	/// </summary>
	public abstract void Stay();

	/// <summary>
	/// 離開時
	/// </summary>
	public abstract void Exit();

}
