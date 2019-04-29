using UnityEngine;
public class ThrowingEffect : EffectBase
{
	private AnimatorManager _animatorManager;

	private Rigidbody2D _rigid;

	private void Start()
	{
		_rigid = GetComponent<Rigidbody2D>();
		_rigid.AddForce(new Vector2(0, Mathf.Abs(Naukri.NMath.Gap(transform.position, Target.transform.position)) * 40f));
		_animatorManager = GetComponent<Animator>();
	}

	private void Update()
	{
		float y = _rigid.position.y;
		Vector3 newPos = Vector3.Lerp(_rigid.transform.position, Target.transform.position, 0.03f);
		if (Mathf.Abs(_rigid.transform.position.x - newPos.x) > 0.1f)
			newPos.x = _rigid.transform.position.x > newPos.x ? _rigid.transform.position.x - 0.1f : _rigid.transform.position.x + 0.1f;
		newPos.y = y;
		_rigid.transform.position = newPos;
		//Debug.Log(tmp + "-->" + _rigid.position);
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject == GameArgs.BackGround)
		{
			_animatorManager.AnimClip = (int)AbilityAnimClip.Dead;
		}
	}
}
