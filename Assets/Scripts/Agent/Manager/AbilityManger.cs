using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 能力管理員
/// </summary>
[Serializable]
[DisallowMultipleComponent]
public class AbilityManager
{
	/// <summary>
	/// 當前能力
	/// </summary>
	public AbilityBase CurrentAbility { get; private set; }

	/// <summary>
	/// 代理的所有能力
	/// </summary>
	public LinkedList<AbilityBase> Abilities { get; private set; }

	/// <summary>
	/// Animator管理員
	/// </summary>
	private AnimatorManager _animatorManager;

	/// <summary>
	/// 建構子
	/// </summary>
	/// <param name="abilities">代理具有的能力</param>
	/// <param name="animator">代理的Animator</param>
	public AbilityManager(AbilityBase[] abilities, Animator animator)
	{
		Array.Sort(abilities, (AbilityBase x, AbilityBase y) => y.Priority.CompareTo(x.Priority));
		Abilities = new LinkedList<AbilityBase>(abilities);
		CurrentAbility = Abilities.Last.Value;
		if (animator != null)
		{
			_animatorManager = animator;
			_animatorManager.AnimClip = (int)CurrentAbility.AnimClip;
		}
	}

	/// <summary>
	/// 自動處理能力
	/// </summary>
	public void ProcessAbility()
	{
		EveryFrameAll();
		AbilityBase nextAbility = ReTriggerAll();
		//
		if (CurrentAbility != nextAbility)
		{
			SwitchAbility(nextAbility);
		}
		else
		{
			CurrentAbility.Stay();
		}
	}

	/// <summary>
	/// 執行個能力每幀初始化
	/// </summary>
	private void EveryFrameAll()
	{
		foreach (AbilityBase ability in Abilities)
		{
			ability.EveryFrame();
		}
	}

	/// <summary>
	/// 重新觸發所有觸發器
	/// </summary>
	/// <returns>符合目前狀態且優先序最高的能力</returns>
	private AbilityBase ReTriggerAll()
	{
		foreach (AbilityBase ability in Abilities)
		{
			if (ability.Triggers())
			{
				return ability;
			}
		}
		return CurrentAbility;
	}

	/// <summary>
	/// 切換能力
	/// </summary>
	/// <param name="nextAbility">下一個能力</param>
	private void SwitchAbility(AbilityBase nextAbility)
	{
		CurrentAbility.Exit();
		CurrentAbility = nextAbility;
		CurrentAbility.Enter();
		if (_animatorManager != null)
		{
			_animatorManager.AnimClip = (int)nextAbility.AnimClip;
		}
	}
}
