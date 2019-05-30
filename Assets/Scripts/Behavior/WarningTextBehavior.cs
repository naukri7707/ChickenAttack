using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningTextBehavior : MonoBehaviour
{
	public Text Text;

	public float aliveTime;

	private void Awake()
	{
		Text = GetComponent<Text>();
	}
	private void OnEnable()
	{
		Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, 1);
		transform.localScale = new Vector3(5, 5, 1);
		aliveTime = 2;
	}

	private void Update()
	{
		if (transform.localScale.x <= 1)
		{
			aliveTime -= Time.deltaTime;
			if (aliveTime <= 0)
			{
				Text.color -= new Color(0, 0, 0, 0.05f);
				if (Text.color.a <= 0.1f)
					gameObject.SetActive(false);
			}
		}
		else
		{
			transform.localScale -= new Vector3(0.1f, 0.1f, 0);
		}
	}
}
