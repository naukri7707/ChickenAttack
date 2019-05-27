using UnityEngine;
public class ThrowingEffect : EffectBase
{
	const float InitForce = 40f;

	const float LerpGap = 0.1f;

	const float SpeedLimiter = 0.007f;

	public float limiter;

	private AnimatorManager _animatorManager;

	private Rigidbody2D _rigid;

	private Vector2 targetPos;
	private void Start()
	{
		transform.Translate(FixPosition);
		_rigid = GetComponent<Rigidbody2D>();
		_rigid.AddForce(new Vector2(0, Mathf.Abs(Naukri.NMath.Gap(transform.position.x, Target.transform.position.x)) * InitForce));
		_animatorManager = GetComponent<Animator>();
		targetPos = _rigid.transform.position;
		limiter = Naukri.NMath.Gap(transform.position.x, Target.transform.position.x) * SpeedLimiter;
		if (limiter < 0.1f)
			limiter = 0.1f;
	}

	private void Update()
	{
		if (Target != null)
			targetPos = Target.transform.position;
		float tmep = transform.position.y;
		Vector3 newPos = Vector3.Lerp(transform.position, targetPos, LerpGap);
		newPos.y = tmep;
		if (Team == AgentTeam.Ally)
		{
			if (newPos.x > transform.position.x + limiter)
			{
				newPos.x = transform.position.x + limiter;
			}
			else if (newPos.x < transform.position.x)
			{
				newPos.x = transform.position.x;
			}
		}
		else
		{
			if (newPos.x < transform.position.x - limiter)
				newPos.x = transform.position.x - limiter;
			else if (newPos.x > transform.position.x)
				newPos.x = transform.position.x;
		}
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
