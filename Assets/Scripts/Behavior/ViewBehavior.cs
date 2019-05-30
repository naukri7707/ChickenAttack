﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewBehavior : MonoBehaviour
{
	float wait = 1;

	private Image view;
	private void Start()
	{
		view = GetComponent<Image>();
		view.color = new Color(0, 0, 0, 0);
		KeepObjects.SetActive(false);
	}

	// Update is called once per frame
	private void Update()
	{
		if (wait <= 0)
		{
			view.color += new Color(0, 0, 0, 0.02f);
			if (view.color.a >= 0.95)
			{
				KeepObjects.SetActive(true);
				SceneManager.LoadScene(1);
			}
		}
		else
		{
			wait -= Time.deltaTime;
		}
	}
}