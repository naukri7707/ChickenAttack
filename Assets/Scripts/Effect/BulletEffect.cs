using UnityEngine;

public class BulletEffect : EffectBase
{
	private AnimatorManager _animatorManager;

	[SerializeField] private float _speed;

	// Start is called before the first frame update
	private void Start()
	{
		_animatorManager = GetComponent<Animator>();
	}

	// Update is called once per frame
	private void Update()
	{
		transform.Translate(_speed, 0, 0);

		if (AttackOnce())
		{
			_animatorManager.AnimClip = (int)AbilityAnimClip.Dead;
		}
	}
}
