using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Naukri.ExtensionMethods;

[DisallowMultipleComponent]
[AddComponentMenu("AgentAbility/Builiding/InstantiateAbility")]
public class InstantiateAbility : AbilityBase
{
	public int CurrentID => _trainList[CurrentIndex];

	public int TempID => _trainList[TempIndex];

	public int CurrentIndex { get; set; }

	private int _tempIndex;
	public int TempIndex
	{
		get => _tempIndex;
		set
		{
			if (value < 0)
				value = _trainList.Length - 1;
			else if (value >= _trainList.Length)
				value = 0;
			_tempIndex = value;
		}
	}

	[SerializeField] private int[] _trainList;

	[SerializeField] [ReadOnly] private float _maxTrainingTime;

	[SerializeField] [ReadOnly] private float _trainingTime;

	private InstantiateAbility()
	{
		Priority = AbilityPriority.Instantiate;
		AnimClip = AbilityAnimClip.Idle;
	}

	private void Start()
	{
		ChangeTraining(0);
		CurrentIndex = TempIndex = 0;
	}

	public override void EveryFrame()
	{
		_trainingTime -= Time.deltaTime;
	}

	public override bool Triggers()
	{
		return _trainingTime <= 0;
	}

	public override void Enter()
	{
		GameObject trainObj = Prefabs.Instantiate(CurrentID);
		CoreBase trainCore = trainObj.GetComponent<CoreBase>();
		//
		trainObj.transform.SetOnHorizon(_agent.transform.position.x);
		trainCore.transform.parent = transform.parent;
		trainCore.SetTeam(_agent.Team);
		TroopDetails det = trainCore.GetDetails<TroopDetails>();
		det.DeBuff.AddFlag(AgentDeBuff.Freeze);
		det.Level = _agent.GetDetails<DetailsBase>().Level;
		float scale = Mathf.Pow(det.GrowthRate, det.Level);
		det.MaxHitPoint = det.HitPoint = (int)(det.MaxHitPoint * scale);
		det.Damage = (int)(det.Damage * scale);
		det.KnockBack = (int)(det.KnockBack * scale);
		det.Gold = (int)(det.Gold * scale);
		_trainingTime = _maxTrainingTime;
	}
	public override void Stay()
	{

	}

	public override void Exit()
	{

	}

	public void ChangeTraining(int index)
	{
		CurrentIndex = index;
		_maxTrainingTime = Prefabs.Troop[CurrentID].GetComponent<CoreBase>().GetDetails<TroopDetails>().TrainingTime;
		_trainingTime = _maxTrainingTime;
	}

}