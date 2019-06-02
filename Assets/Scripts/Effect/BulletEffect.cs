using UnityEngine;

public class BulletEffect : EffectBase
{
	[SerializeField] private float _speed;

	// Start is called before the first frame update
	public override void Initialization(CoreBase target, int damage, AgentTeam team)
	{
		base.Initialization(target, damage, team);
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
