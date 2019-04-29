/// <summary>
/// 代理異常狀態
/// </summary>
[System.Serializable]
[System.Flags]
public enum AgentDeBuff
{
	Freeze = 1,
}

/// <summary>
/// 代理異常狀態擴充函式
/// </summary>
static class AgentDeBuffMethods
{
	/// <summary>
	/// 新增狀態
	/// </summary>
	/// <param name="value">目標</param>
	/// <param name="addFlag">要新增的狀態</param>
	public static void AddFlag(this AgentDeBuff value, AgentDeBuff addFlag)
	{
		value |= addFlag;
	}

	/// <summary>
	/// 刪除狀態
	/// </summary>
	/// <param name="value">目標</param>
	/// <param name="delFlag">要刪除的狀態</param>
	public static void DelFlag(this AgentDeBuff value, AgentDeBuff delFlag)
	{
		value ^= delFlag;
	}

	/// <summary>
	/// 判斷狀態
	/// </summary>
	/// <param name="value">目標</param>
	/// <param name="targetFlag">要判斷的狀態</param>
	/// <returns></returns>
	public static bool HasFlag(this AgentDeBuff value, AgentDeBuff targetFlag)
	{
		return (value & targetFlag) == targetFlag;
	}

	/// <summary>
	/// 清空狀態
	/// </summary>
	/// <param name="value">目標</param>
	public static void Clear(this AgentDeBuff value)
	{
		value &= 0;
	}
}