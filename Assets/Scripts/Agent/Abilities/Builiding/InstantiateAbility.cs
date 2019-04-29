using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Naukri.ExtensionMethods;

[DisallowMultipleComponent]
[AddComponentMenu("AgentAbility/Builiding/InstantiateAbility")]
public class InstantiateAbility : AbilityBase
{
    public int _currentTrainID;

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
        ChangeTraining(_trainList[0]);

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
        GameObject trainObj = Prefabs.Instantiate(_currentTrainID);
        CoreBase trainCore = trainObj.GetComponent<CoreBase>();
        //
        trainObj.transform.SetOnHorizon(_agent.transform.position.x);
        trainCore.transform.parent = transform.parent;
        trainCore.SetTeam(_agent.Team);
        trainCore.GetDetails<DetailsBase>().DeBuff.AddFlag(AgentDeBuff.Freeze);
        _trainingTime = _maxTrainingTime;
    }
    public override void Stay()
    {

    }

    public override void Exit()
    {

    }

    private void ChangeTraining(int identify)
    {
        Debug.Log(identify);
        _currentTrainID = identify;
        _maxTrainingTime = Prefabs.Troop[identify].GetComponent<CoreBase>().GetDetails<TroopDetails>().TrainingTime;
        _trainingTime = _maxTrainingTime;
    }
}