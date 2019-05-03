/// <summary>
/// 動作優先序
/// </summary>
public enum AbilityPriority
{
	None = -2147483648,
	Idle = -2147483647,
	FadeIn = 2147483646,
	Dead = 2147483647,
	//
	Move = 0,
	Attack = 10,
	Alert = 20,
	//
	Instantiate = 1000,
	GoldProduce = -9999,
}

/// <summary>
/// 動作ID (連接Animator)
/// </summary>
public enum AbilityAnimClip
{
	Idle = 0,
	Dead = 1,
	Move = 2,
	Attack = 3,
	Alert = 4,
}