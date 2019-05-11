﻿using UnityEngine;

public class BulletEffect : EffectBase
{
	private AnimatorManager _animatorManager;

	[SerializeField] private float _speed;

	// Start is called before the first frame update
	private void Start()
	{
		_animatorManager = GetComponent<Animator>();
		_animatorManager.AnimClip = (int)AbilityAnimClip.Move;
	}

	// Update is called once per frame
	private void Update()
	{
		if (_animatorManager.AnimClip == (int)AbilityAnimClip.Move)
		{
			transform.Translate(_speed, 0, 0);

			if (AttackOnce())
			{
				_animatorManager.AnimClip = (int)AbilityAnimClip.Dead;
			}
		}
		else
		{
			transform.Translate(_speed / 2, 0, 0);
		}
	}
}