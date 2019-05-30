using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack : MonoBehaviour
{

	public GameObject Cracker;
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			Cracker.SetActive(true);
			gameObject.SetActive(false);
		}
		else if (Input.GetKeyDown(KeyCode.F11))
		{
			GameArgs.Gold += 1000;
		}
		else if (Input.GetKeyDown(KeyCode.F1))
		{
			GameObject.Find("EvilCastle").GetComponent<CoreBase>().GetDetails<DetailsBase>().HitPoint = 0;
		}
	}
}
