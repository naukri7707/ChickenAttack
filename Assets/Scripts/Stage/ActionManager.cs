using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 動作管理員
/// </summary>
public class ActionManager : MonoBehaviour
{
	/// <summary>
	/// 動作表
	/// </summary>
	[SerializeField] private List<ActionBase> _actions;

	/// <summary>
	/// 初始化
	/// </summary>
	/// <returns></returns>
	private async void Start()
	{
		_actions = new List<ActionBase>();
		Naukri.IO.GetStage(out _actions, GameArgs.CurrentStage);
		Stack<int> currentLoops = new Stack<int>();
		for (int i = 0; i < _actions.Count; i++)
		{
			switch (_actions[i].Type)
			{
				case ActionType.Train:
					{
						await _actions[i].As<TrainAction>().DoActionAsync(transform.GetComponent<CoreBase>());
						break;
					}
				case ActionType.Delay:
					{
						await _actions[i].DoActionAsync();
						break;
					}
				case ActionType.Loop:
					{
						_actions[i].As<LoopAction>().currentLoopTime = _actions[i].As<LoopAction>().LoopTimes;
						currentLoops.Push(i);
						break;
					}
				case ActionType.EndLoop:
					{
						int j = currentLoops.Peek();
						_actions[j].As<LoopAction>().currentLoopTime--;
						if (_actions[j].As<LoopAction>().currentLoopTime > 0) i = j;
						else currentLoops.Pop();
						break;
					}
				case ActionType.LevelUp:
					{
						var war = new WarningAction();
						war.WarningType = WarningType.LevelUp;
						war.DoAction();
						_actions[i].As<LevelUpAction>().DoAction(transform.GetComponent<CoreBase>());
						break;
					}
				case ActionType.Warning:
					{
						_actions[i].As<WarningAction>().DoAction();
						break;
					}
				case ActionType.BossWave:
					{
						var war = new WarningAction();
						var obj = Prefabs.Instantiate(_actions[i].As<BossWaveAction>().Identify);
						war.CustomText = obj.GetComponent<CoreBase>().Details.Name;
						Destroy(obj);
						war.WarningType = WarningType.BossWave;
						war.DoAction();
						await _actions[i].As<BossWaveAction>().DoActionAsync(transform.GetComponent<CoreBase>());
						break;
					}
				case ActionType.ChickenRain:
					{
						var war = new WarningAction();
						var obj = Prefabs.Instantiate(_actions[i].As<ChickenRainAction>().Identify);
						war.CustomText = obj.GetComponent<CoreBase>().Details.Name;
						Destroy(obj);
						war.WarningType = WarningType.ChickenRain;
						war.DoAction();
						await _actions[i].As<ChickenRainAction>().DoActionAsync();
						break;
					}
			}
		}
	}
}
