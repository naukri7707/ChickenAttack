using UnityEngine;
public class ThrowingEffect : EffectBase
{
	private AnimatorManager _animatorManager;

	private Rigidbody2D _rigid;

	private Vector2 targetPos;
	private void Start()
	{
		transform.Translate(FixPosition);
		_rigid = GetComponent<Rigidbody2D>();
		_rigid.AddForce(new Vector2(0, Mathf.Abs(Naukri.NMath.Gap(transform.position, Target.transform.position)) * 40f));
		_animatorManager = GetComponent<Animator>();
		targetPos = _rigid.transform.position;
	}

	private void Update()
	{
		if (Target != null)
			targetPos = Target.transform.position;
		float y = transform.position.y;
		Vector3 newPos = Vector3.Lerp(transform.position, targetPos, 0.02f);
		if (newPos.x - transform.position.x > 0.1f)
			newPos.x = transform.position.x > newPos.x ? transform.position.x - 0.1f : transform.position.x + 0.1f;
		else if (newPos.x - transform.position.x <= 0)
			newPos.x = transform.position.x;
		newPos.y = y;
		transform.position = newPos;
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject == GameArgs.Ground)
		{
			_animatorManager.AnimClip = (int)AbilityAnimClip.Dead;
		}
	}
}
