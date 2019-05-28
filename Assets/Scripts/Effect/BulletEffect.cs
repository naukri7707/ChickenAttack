using UnityEngine;

public class BulletEffect : EffectBase
{
	[SerializeField] private float _speed;

	// Start is called before the first frame update
	private void Start()
	{
		transform.Translate(FixPosition);
		_speed = Mathf.Abs(_speed) * (TargetTeam == AgentTeam.Ally ? -1 : 1);
		AnimatorManager = GetComponent<Animator>();
		AnimatorManager.AnimClip = (int)AbilityAnimClip.Move;
	}

	// Update is called once per frame
	private void Update()
	{
		if (Target == null)
		{
			AnimatorManager.AnimClip = (int)AbilityAnimClip.Dead;
		}
		if (AnimatorManager.AnimClip == (int)AbilityAnimClip.Move)
		{
			transform.Translate(_speed, 0, 0);

			if (IsCollisionWithEnemy())
			{
				AnimatorManager.AnimClip = (int)AbilityAnimClip.Dead;
			}
		}
		else 
		{
			transform.Translate(_speed / 2, 0, 0);
		}
	}
}
