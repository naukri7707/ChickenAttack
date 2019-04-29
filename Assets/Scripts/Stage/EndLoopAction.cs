using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class EndLoopAction : ActionBase
{
    public EndLoopAction()
    {
        Type = ActionType.EndLoop;
    }

    public override Task DoActionAsync()
    {
        throw new System.NotImplementedException();
    }
}
