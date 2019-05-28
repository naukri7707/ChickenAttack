using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepObjects : MonoBehaviour
{
	[SerializeField] private GameObject[] keeps;

	public static GameObject[] Keeps = new GameObject[0];
	// Start is called before the first frame update
	void Awake()
	{
		Keeps = keeps;
		foreach (var k in keeps)
			DontDestroyOnLoad(k);
	}

	public static void SetActive(bool active)
	{
		foreach (var k in Keeps)
		{
			k.SetActive(active);
		}
	}
}
