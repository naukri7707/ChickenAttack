using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class LoopAction : ActionBase
{
	public int LoopTimes = 1;

	public int currentLoopTime;

	public LoopAction()
	{
		Type = ActionType.Loop;
	}

    public override Task DoActionAsync()
    {
        throw new System.NotImplementedException();
    }
}
