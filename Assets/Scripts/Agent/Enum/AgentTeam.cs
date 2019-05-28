using UnityEngine;
/// <summary>
/// 代理隊伍
/// </summary>
[System.Serializable]
public enum AgentTeam
{
	Ally = 10,
	Enemy = 11,
}

/// <summary>
/// 代理異常狀態擴充函式
/// </summary>
static class AgentTeamMethods
{
	/// <summary>
	/// 新增狀態
	/// </summary>
	/// <param name="value">目標</param>
	/// <param name="addFlag">要新增的狀態</param>
	public static LayerMask AllyLayerMask(this AgentTeam value)
	{
		return 1 << (int)value;
	}
	public static LayerMask EnemyLayerMask(this AgentTeam value)
	{
		return 1 << (int)(value == AgentTeam.Ally ? AgentTeam.Enemy : AgentTeam.Ally);
	}
}