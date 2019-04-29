using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 動作基底
/// </summary>
[System.Serializable]
public abstract class ActionBase
{
	/// <summary>
	/// 動作類別
	/// </summary>
    public ActionType Type;

	/// <summary>
	/// 視作子類別
	/// </summary>
	/// <typeparam name="T">目標類別</typeparam>
	/// <returns></returns>
	public T As<T>() where T : ActionBase
    {
        return (T)this;
    }
    
	/// <summary>
	/// 異步運行動作
	/// </summary>
	/// <returns></returns>
    public abstract Task DoActionAsync();
}
