using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 動畫管理員
/// </summary>
public class AnimatorManager
{
	/// <summary>
	/// 對應的Animator
	/// </summary>
	private readonly Animator _animator;

	/// <summary>
	/// 建構子
	/// </summary>
	/// <param name="animator">欲控制的Animator</param>
	public AnimatorManager(Animator animator)
	{
		_animator = animator;
	}

	/// <summary>
	/// 隱式轉換Animator -> AnimatorManager
	/// </summary>
	/// <param name="animator">源Animator</param>
	public static implicit operator AnimatorManager(Animator animator)
	{
		return new AnimatorManager(animator);
	}

	/// <summary>
	/// 能力ID雜湊值
	/// </summary>
	private readonly int _animHash = Animator.StringToHash("AnimClip");

	/// <summary>
	/// 能力ID
	/// </summary>
	public int AnimClip
	{
		get
		{
			return _animator.GetInteger(_animHash);
		}
		set
		{
			_animator.SetInteger(_animHash, value);
		}
	}

}
