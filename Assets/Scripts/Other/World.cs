using Naukri.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour
{
	/// <summary>
	/// 預設材質
	/// </summary>
	public Material MaterialDefault;

	/// <summary>
	/// 毛玻璃材質
	/// </summary>
	public Material MaterialBlurGass;

	/// <summary>
	/// 灰階材質
	/// </summary>
	public Material MateriaGrayScale;

	public GameObject argsWorld;

	public GameObject argsGround;

	public GameObject argsBackGround;

	public GameObject argsBuildingList;

	public Text WarningText;

	public AudioSource FX_Apply;

	public AudioSource FX_Cancel;
	// Use this for initialization
	void Awake()
	{
		Time.timeScale = 1;
		GameArgs.World = argsWorld;
		GameArgs.Ground = argsGround;
		GameArgs.BackGround = argsBackGround;
		GameArgs.BuildingList = argsBuildingList;
		GameArgs.Horizon = GameArgs.Ground.GetComponent<Collider2D>().GetBoundsRect().yMax;
		GameArgs.Gold = 0;
		GameArgs.FocusPermit = true;
		GameArgs.WarningText = WarningText;
	}
}
