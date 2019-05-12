using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F11))
		{
			GameArgs.Gold += 100;
		}
	}
}
