using Naukri.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
	public GameObject argsWorld;

	public GameObject argsGround;

	public GameObject argsBackGround;

	public GameObject argsBuildingList;

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
	}
}
