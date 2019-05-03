using Naukri.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
	// Use this for initialization
	void Awake()
	{
		Time.timeScale = 1;
		GameArgs.World = GameObject.Find("World");
		GameArgs.BackGround = GameObject.Find("BackGround");
		GameArgs.Horizon = GameArgs.BackGround.GetComponent<Collider2D>().GetBoundsRect().yMax;
		GameArgs.Gold = 0;
	}

}
