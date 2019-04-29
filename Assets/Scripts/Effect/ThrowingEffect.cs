using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingEffect : EffectBase
{
	private AnimatorManager _animatorManager;

	private Rigidbody2D _rigid;

	void Start()
	{
		_rigid = GetComponent<Rigidbody2D>();
		_rigid.AddForce(new Vector2(0, Mathf.Abs(Naukri.NMath.Gap(transform.position, Target.transform.position)) * 30f));
		_animatorManager = GetComponent<Animator>();
	}

	private void Update()
	{
		Vector2 tmp = _rigid.position;
		_rigid.position += Vector2.Lerp(transform.position, TargetPosition, 0.3f);
		Debug.Log(tmp + " --> " + _rigid.position);
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject == GameArgs.BackGround)
		{
			_animatorManager.AnimClip = (int)AbilityAnimClip.Dead;
		}
	}
}
