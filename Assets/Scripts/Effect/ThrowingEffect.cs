using UnityEngine;
public class ThrowingEffect : EffectBase
{
	private AnimatorManager _animatorManager;

	private Rigidbody2D _rigid;

	private Vector2 targetPos;
	private void Start()
	{
		_rigid = GetComponent<Rigidbody2D>();
		_rigid.AddForce(new Vector2(0, Mathf.Abs(Naukri.NMath.Gap(transform.position, Target.transform.position)) * 40f));
		_animatorManager = GetComponent<Animator>();
		targetPos = _rigid.transform.position;
	}

	private void Update()
	{
		if (Target != null)
			targetPos = Target.transform.position;
		float y = _rigid.position.y;
		Vector3 newPos = Vector3.Lerp(_rigid.transform.position, targetPos, 0.02f);
		if (Mathf.Abs(_rigid.transform.position.x - newPos.x) > 0.2f)
			newPos.x = _rigid.transform.position.x > newPos.x ? _rigid.transform.position.x - 0.2f : _rigid.transform.position.x + 0.2f;
		newPos.y = y;
		_rigid.transform.position = newPos;
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject == GameArgs.Ground)
		{
			_animatorManager.AnimClip = (int)AbilityAnimClip.Dead;
		}
	}
}
