using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public enum WarningType
{
	Custom,
	LevelUp,
	Warning,
	LastWave,
	BossWave,
	ChickenRain,
}

[System.Serializable]
public struct NColor
{
	public NColor(float r, float g, float b, float a) : this()
	{
		this.r = r;
		this.g = g;
		this.b = b;
		this.a = a;
	}

	public float r, g, b, a;

	public static implicit operator NColor(Color color)
	{
		return new NColor(color.r, color.g, color.b, color.a);
	}

	public static implicit operator Color(NColor color)
	{
		return new Color(color.r, color.g, color.b, color.a);
	}
}

[System.Serializable]
public class WarningAction : ActionBase
{

	public WarningType WarningType;

	public string CustomText;

	public NColor TextColor;

	public WarningAction()
	{
		Type = ActionType.Warning;
	}

	public void DoAction()
	{
		if (GameArgs.WarningText.gameObject.activeSelf == true)
			GameArgs.WarningText.gameObject.SetActive(false);
		GameArgs.WarningText.color = SelectColor();
		switch (WarningType)
		{
			case WarningType.Custom:
				GameArgs.WarningText.text = CustomText;
				break;
			case WarningType.LevelUp:
				GameArgs.WarningText.text = "敵方等級提升!!";
				break;
			case WarningType.Warning:
				GameArgs.WarningText.text = "一大波小雞來襲!!";
				break;
			case WarningType.LastWave:
				GameArgs.WarningText.text = "最後一波!";
				break;
			case WarningType.BossWave:
				GameArgs.WarningText.text = "巨型" + CustomText + "來襲!!";
				break;
			case WarningType.ChickenRain:
				GameArgs.WarningText.text = CustomText + "雨!!";
				break;
		}
		GameArgs.WarningText.gameObject.SetActive(true);
	}

	public override Task DoActionAsync()
	{
		throw new System.NotImplementedException();
	}

	public Color SelectColor()
	{
		switch (WarningType)
		{
			case WarningType.Custom:
				return TextColor;
			case WarningType.LevelUp:
				return Color.yellow;
			default:
				return Color.red;
		}
	}
}
